﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject deathExplosionPrefab;
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

    public void Die()
    {
        Instantiate(deathExplosionPrefab,
                    transform.position,
                    transform.rotation);

        gameObject.GetComponent<Tweening>().DestroyHomeLocation();
        GameObject.Destroy(gameObject);
    }

    void GenerateBullet()
    {
        Instantiate(bulletPrefab,
                    bulletSpawnPoint.position,
                    bulletSpawnPoint.rotation);
    }

    void ResetTimer()
    {
        firingTimer = 0;
    }
}
