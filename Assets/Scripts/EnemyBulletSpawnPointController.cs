using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawnPointController : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        Transform playerTransform = player.transform;
        Vector3 targetPosition = new Vector3(
            playerTransform.position.x,
            playerTransform.position.y,
            transform.position.z
        );
        Vector3 direction = (targetPosition - transform.position).normalized;
        float z = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
