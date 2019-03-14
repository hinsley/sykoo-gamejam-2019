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
    [Tooltip("How long the agent will remain motionless before tweening to this checkpoint.")]
    public float waitTime = 0f;
    public bool firing;
    public float radius = 0.5f;
}
