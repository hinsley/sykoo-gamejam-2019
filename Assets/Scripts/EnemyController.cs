using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateBullet", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateBullet()
    {
        Instantiate(bulletPrefab,
                    bulletSpawnPoint.position,
                    transform.rotation);
    }
}
