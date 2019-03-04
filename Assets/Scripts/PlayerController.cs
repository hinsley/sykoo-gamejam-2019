using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("How many bullets can be fired per second.")]
    public float fireRate;
    public float moveSpeed;
    public GameObject bulletPrefab;
    public GameObject deathExplosionPrefab;
    public Transform bulletSpawnPoint;
    public Transform leftBoundary;
    public Transform rightBoundary;

    private bool readyToFire = true;
    private float timeSinceLastFire = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateLocation();

        GenerateBullet();

        timeSinceLastFire += Time.deltaTime;
        if (timeSinceLastFire >= 1 / fireRate)
        {
            readyToFire = true;
        }
    }

    public void Die()
    {
        Instantiate(deathExplosionPrefab,
                    transform.position,
                    transform.rotation);

        GameObject.Destroy(gameObject);
    }

    void GenerateBullet()
    {
        if (Input.GetButton("Fire1") && readyToFire)
        {
            Instantiate(bulletPrefab,
                        bulletSpawnPoint.position,
                        transform.rotation);
            timeSinceLastFire = 0;
            readyToFire = false;
        }
    }

    void UpdateLocation()
    {
        transform.Translate(Vector3.right *
                            moveSpeed *
                            Time.deltaTime *
                            Input.GetAxisRaw("Horizontal"));
        
        if (transform.position.x < leftBoundary.position.x)
        {
            UpdateX(leftBoundary.position.x);
        }
        else if (transform.position.x > rightBoundary.position.x)
        {
            UpdateX(rightBoundary.position.x);
        }
    }

    void UpdateX(float newX)
    {
        transform.position = new Vector3(
            newX,
            transform.position.y,
            transform.position.z
        );
    }
}
