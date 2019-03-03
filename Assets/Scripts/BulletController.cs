using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float travelSpeed;
    
    GameObject bulletTerminator;

    // Start is called before the first frame update
    void Start()
    {
        bulletTerminator = GameObject.Find("Bullet Terminator");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * travelSpeed * Time.deltaTime);

        if (gameObject.GetComponent<BoxCollider2D>().IsTouching(
                bulletTerminator.GetComponent<BoxCollider2D>()
        ))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Foo");
        if (other.tag == "BulletTerminator")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
