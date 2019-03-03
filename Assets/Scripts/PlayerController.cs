using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftBoundary;
    public Transform rightBoundary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLocation();
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
