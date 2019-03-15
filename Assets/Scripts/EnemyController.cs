using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject deathExplosionPrefab;
    public AudioClip deathSound;
    public AudioClip dispatchSound;
    public Transform bulletSpawnPoint;
    // How many bullets are fired per second.
    public float fireRate;
    public bool firing = false;
    public int killScore;

    float firingTimer = 0;
    GameObject scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.FindGameObjectWithTag("ScoreDisplay");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (firing && player != null && player.activeInHierarchy)
        {
            firingTimer += Time.deltaTime;
            if (firingTimer >= 1 / fireRate)
            {
                GenerateBullet();
                ResetTimer();
            }
        }
        else
        {
            ResetTimer();
        }
    }

    public void Die(bool killedByPlayer=true)
    {
        if (killedByPlayer)
        {
            PlayDeathSound();
            Instantiate(deathExplosionPrefab,
                        transform.position,
                        transform.rotation);

            Tweening tweening = gameObject.GetComponent<Tweening>();
            bool inTransit = tweening.inAnimationTransit ||
                            tweening.inFlyInTransit ||
                            tweening.inHomecomingTransit;
            
            scoreDisplay.GetComponent<ScoreDisplay>().score += (inTransit ? killScore * 2 : killScore);
        }

        gameObject.GetComponent<Tweening>().DestroyHomeLocation();
        GameObject.Destroy(gameObject);
    }

    void GenerateBullet()
    {
        Instantiate(bulletPrefab,
                    bulletSpawnPoint.position,
                    bulletSpawnPoint.rotation);
    }

    void PlayDeathSound()
    {
        Utils.GetAudioSource().PlayOneShot(deathSound);
    }

    public void PlayDispatchSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(dispatchSound);
    }

    void ResetTimer()
    {
        firingTimer = 0;
    }
}
