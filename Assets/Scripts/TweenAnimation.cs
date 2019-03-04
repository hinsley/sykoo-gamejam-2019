using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TweenAnimation : MonoBehaviour
{
    public TweenAnimationCheckpoint[] checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class TweenAnimationCheckpoint
{
    public Transform transform;
    public float flySpeed;
    public float turnSpeed;
    public bool firing;
    public float radius = 0.5f;
}
