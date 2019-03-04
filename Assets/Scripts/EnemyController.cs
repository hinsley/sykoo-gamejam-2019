using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    // How many bullets are fired per second.
    public float fireRate;
    public bool firing = false;

    private float firingTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (firing)
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

    void Death(GameObject bullet)
    {
        GameObject.Destroy(bullet);
        GameObject.Destroy(gameObject);
    }

    void GenerateBullet()
    {
        Instantiate(bulletPrefab,
                    bulletSpawnPoint.position,
                    bulletSpawnPoint.rotation);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlayerProjectile")
        {
            Death(other.gameObject);
        }
    }

    void ResetTimer()
    {
        firingTimer = 0;
    }
}
