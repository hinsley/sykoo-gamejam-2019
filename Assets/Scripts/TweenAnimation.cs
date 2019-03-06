using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TweenAnimation : MonoBehaviour
{
    public TweenAnimationCheckpoint[] checkpoints;
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
