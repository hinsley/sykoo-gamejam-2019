using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBreathe : MonoBehaviour
{
    public float breathScaleDuration;
    public float breathSwayDuration;
    public float maxScaleOffset;
    public float maxSwayOffset;
    
    private float originalXPosition;
    private float originalXScale;
    private float originalYScale;
    private float timeElapsedInBreathScale;
    private float timeElapsedInBreathSway;

    // Start is called before the first frame update
    void Start()
    {
        originalXScale = transform.localScale.x;
        originalYScale = transform.localScale.y;
        originalXPosition = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsedInBreathScale = (timeElapsedInBreathScale + Time.deltaTime) % breathScaleDuration;
        // [0.0, 1.0]
        float breathScalePoint = timeElapsedInBreathScale / breathScaleDuration;
        timeElapsedInBreathSway = (timeElapsedInBreathSway + Time.deltaTime) % breathSwayDuration;
        // [0.0, 1.0]
        float breathSwayPoint = timeElapsedInBreathSway / breathSwayDuration;
        UpdateValues(breathScalePoint, breathSwayPoint);
    }

    void UpdateValues(float breathScalePoint, float breathSwayPoint)
    {
        float scaleOffset = Mathf.Sin(breathScalePoint * Mathf.PI * 2) * maxScaleOffset;
        transform.localScale = new Vector3(
            scaleOffset + originalXScale,
            scaleOffset + originalYScale,
            transform.localScale.z
        );

        transform.localPosition = new Vector3(
            Mathf.Sin(breathSwayPoint * Mathf.PI * 2) * maxSwayOffset + originalXPosition, 
            transform.localPosition.y,
            transform.localPosition.z
        );
    }
}
