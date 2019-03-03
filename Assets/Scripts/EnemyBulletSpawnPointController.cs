using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawnPointController : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z
        );
        Vector3 direction = (targetPosition - transform.position).normalized;
        float z = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
