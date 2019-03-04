using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweening : MonoBehaviour
{
    [Tooltip("Do not set the Transform field within this item.")]
    public TweenAnimationCheckpoint homecomingCheckpoint;
    public GameObject flyInSpawner;

    private GameObject homeLocation;
    private TweenAnimation[] animations;
    private TweenAnimationCheckpoint[] checkpointQueue;
    private int currentCheckpointIndex;
    private Transform targetTransform;
    private float flySpeed;
    private float turnSpeed;
    private bool inAnimationTransit = false;
    private bool inHomecomingTransit = false;
    private bool inFlyInTransit = false;

    // Start is called before the first frame update
    void Start()
    {
        homeLocation = new GameObject();
        homeLocation.transform.position = transform.position;
        homeLocation.transform.rotation = transform.rotation;
        homecomingCheckpoint.transform = homeLocation.transform;
        FlyIn();
    }

    // Update is called once per frame
    void Update()
    {
        // If playing an animation...
        if (inAnimationTransit)
        {
            // If reached checkpoint...
            if (ReachedCheckpoint(checkpointQueue[currentCheckpointIndex]))
            {
                Debug.LogFormat("{0} reached checkpoint {1}.",
                                gameObject.name,
                                currentCheckpointIndex);
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
                    TweenToCheckpoint(checkpointQueue[currentCheckpointIndex]);
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
                animations = gameObject.GetComponentsInChildren<TweenAnimation>();
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
                TweenToCheckpoint(checkpointQueue[currentCheckpointIndex]);
            }
        }
    }

    void FlyIn()
    {
        inFlyInTransit = true;
        transform.position = flyInSpawner.transform.position;
        transform.rotation = flyInSpawner.transform.rotation;
        animations = flyInSpawner.GetComponentsInChildren<TweenAnimation>();
        PlayRandomAnimation();
    }

    // Play the animation at the supplied index.
    public void PlayAnimation(int index) => QueueUpTweenAnimation(animations[index]);

    public void PlayRandomAnimation()
    {
        System.Random rand = new System.Random();
        int index = rand.Next(0, animations.Length);
        PlayAnimation(index);
    }

    void QueueUpTweenAnimation(TweenAnimation animation)
    {
        checkpointQueue = animation.checkpoints;
        currentCheckpointIndex = 0;
    }

    bool ReachedCheckpoint(TweenAnimationCheckpoint checkpoint)
    {
        return Vector3.Distance(
            transform.position,
            checkpoint.transform.position
        ) < checkpoint.radius;
    }

    void TweenToCheckpoint(TweenAnimationCheckpoint checkpoint)
    {
        targetTransform = checkpoint.transform;
        flySpeed = checkpointQueue[currentCheckpointIndex].flySpeed;
        turnSpeed = checkpointQueue[currentCheckpointIndex].turnSpeed;
        UpdateFiring();
        inAnimationTransit = true;
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
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        float z = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
        Quaternion goalRotation = Quaternion.Euler(0, 0, z);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            goalRotation,
            turnSpeed
        );
    }
}
