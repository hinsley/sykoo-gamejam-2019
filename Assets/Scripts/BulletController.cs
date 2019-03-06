using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float travelSpeed;
    public AudioClip soundEffect;
    
    private GameObject bulletTerminator;
    private EnemyController destroyedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        Utils.GetAudioSource().PlayOneShot(soundEffect);
        bulletTerminator = GameObject.Find("Bullet Terminator");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * travelSpeed * Time.deltaTime);
        if (destroyedEnemy != null)
        {
            destroyedEnemy.Die();
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "BulletTerminator")
        {
            GameObject.Destroy(gameObject);
        }
        else if (gameObject.tag == "PlayerProjectile" && other.tag == "Enemy")
        {
            destroyedEnemy = other.gameObject.GetComponent<EnemyController>();
        }
        else if (gameObject.tag == "EnemyProjectile" && other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Die();
            GameObject.Destroy(gameObject);
        }
    }
}
