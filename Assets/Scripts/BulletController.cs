using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float travelSpeed;
    public AudioClip soundEffect;
    
    GameObject bulletTerminator;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
        bulletTerminator = GameObject.Find("Bullet Terminator");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * travelSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "BulletTerminator")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
