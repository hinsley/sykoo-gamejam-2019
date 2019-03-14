using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweening : MonoBehaviour
{
    [Tooltip("Do not set the Transform field within this item.")]
    public TweenAnimationCheckpoint homecomingCheckpoint;
    public GameObject level;
    public GameObject flyInSpawner;
    [System.NonSerialized]
    public bool inAnimationTransit = false;
    [System.NonSerialized]
    public bool inHomecomingTransit = false;
    [System.NonSerialized]
    public bool inFlyInTransit = false;

    private LevelBreathe levelBreathe;
    private GameObject homeLocation;
    private TweenAnimation[] animations;
    private TweenAnimationCheckpoint[] checkpointQueue;
    private int currentCheckpointIndex;
    private Transform targetTransform;
    private float flySpeed;
    private float turnSpeed;
    private float timeSinceLastCheckpoint;
    private bool tweenToCheckpointInvoked = false;

    void Awake()
    {
        levelBreathe = level.GetComponent<LevelBreathe>();
        homeLocation = new GameObject();
        homeLocation.transform.position = transform.position;
        homeLocation.transform.rotation = transform.rotation;
        homecomingCheckpoint.transform = homeLocation.transform;
        homeLocation.transform.parent = transform.parent;
        FlyIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!tweenToCheckpointInvoked)
        {
            timeSinceLastCheckpoint += Time.deltaTime;

            // If playing an animation...
            if (inAnimationTransit && !tweenToCheckpointInvoked)
            {
                // If reached checkpoint...
                if (ReachedCheckpoint(checkpointQueue[currentCheckpointIndex]))
                {
                    Debug.LogFormat("{0} reached checkpoint {1}.",
                                    gameObject.name,
                                    currentCheckpointIndex + 1);
                    // If reached end of checkpoint queue for the current
                    // animation...
                    if (++currentCheckpointIndex >= checkpointQueue.Length)
                    {
                        inAnimationTransit = false;
                        inHomecomingTransit = true;
                        inFlyInTransit = false;
                        gameObject.GetComponent<EnemyController>().firing = false;
                        targetTransform = homecomingCheckpoint.transform;
                        flySpeed = homecomingCheckpoint.flySpeed;
                        turnSpeed = homecomingCheckpoint.turnSpeed;
                    }
                    else
                    {
                        InvokeTweenToCheckpoint();
                    }
                }
                UpdatePosition();
                UpdateRotation();
            }
            else if (inHomecomingTransit)
            {
                if (ReachedCheckpoint(homecomingCheckpoint))
                {
                    Debug.LogFormat(
                        "{0} reached home location checkpoint.",
                        gameObject.name
                    );
                    transform.position = homecomingCheckpoint.transform.position;
                    transform.rotation = homecomingCheckpoint.transform.rotation;
                    inHomecomingTransit = false;
                    animations = gameObject.GetComponentInChildren<TweenAnimationLibrary>().animations;
                    gameObject.GetComponent<AudioSource>().Stop();
                }
                else
                {
                    UpdatePosition();
                    UpdateRotation();
                }
            }
            else
            {
                // If not done running through current checkpoint queue...
                if (currentCheckpointIndex < checkpointQueue.Length)
                {
                    InvokeTweenToCheckpoint();
                }
            }
        }
    }

    public bool isIdle
    {
        get
        {
            return !inFlyInTransit ||
                   !inAnimationTransit ||
                   !inHomecomingTransit ||
                   currentCheckpointIndex != 0;
        }
    }

    public void DestroyHomeLocation()
    {
        GameObject.Destroy(homeLocation);
    }

    void FlyIn()
    {
        inFlyInTransit = true;
        animations = flyInSpawner.GetComponentInChildren<TweenAnimationLibrary>().animations;
        flyInSpawner.GetComponent<FlyInQueue>().AddItem(gameObject);
        PlayRandomAnimation();
    }

    // Play the animation at the supplied index.
    public void PlayAnimation(int index) => QueueUpTweenAnimation(animations[index]);

    public void PlayRandomAnimation()
    {

        System.Random rand = new System.Random();
        int index = rand.Next(0, animations.Length);
        QueueUpTweenAnimation(Utils.GetRandomElement(animations));
    }

    void QueueUpTweenAnimation(TweenAnimation animation)
    {
        checkpointQueue = animation.checkpoints;
        currentCheckpointIndex = 0;
    }

    bool ReachedCheckpoint(TweenAnimationCheckpoint checkpoint)
    {
        return Vector3.Distance(
            transform.localPosition,
            checkpoint.transform.localPosition
        ) < checkpoint.radius;
    }

    void InvokeTweenToCheckpoint()
    {
        if (!tweenToCheckpointInvoked)
        {
            TweenAnimationCheckpoint checkpoint = checkpointQueue[currentCheckpointIndex];
            tweenToCheckpointInvoked = true;
            Invoke("TweenToCheckpoint", checkpoint.waitTime);
        }
    }

    void TweenToCheckpoint()
    {
        TweenAnimationCheckpoint checkpoint = checkpointQueue[currentCheckpointIndex];
        tweenToCheckpointInvoked = false;
        targetTransform = checkpoint.transform;
        flySpeed = checkpointQueue[currentCheckpointIndex].flySpeed;
        turnSpeed = checkpointQueue[currentCheckpointIndex].turnSpeed;
        UpdateFiring();
        inAnimationTransit = true;
        timeSinceLastCheckpoint = 0;
    }

    void UpdateFiring()
    {
        gameObject.GetComponent<EnemyController>().firing = checkpointQueue[currentCheckpointIndex].firing;
    }

    void UpdatePosition()
    {
        transform.Translate(
            Vector3.up * flySpeed * Time.deltaTime,
            transform
        );
    }

    void UpdateRotation()
    {
        Vector3 direction = (targetTransform.localPosition - transform.localPosition).normalized;
        float z = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
        Quaternion goalRotation = Quaternion.Euler(0, 0, z);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            goalRotation,
            turnSpeed * Mathf.Sqrt(timeSinceLastCheckpoint)
        );
    }
}
