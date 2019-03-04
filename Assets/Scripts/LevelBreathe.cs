using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBreathe : MonoBehaviour
{
    public float breathDuration;
    public float maxXScaleOffset;
    public float maxYScaleOffset;
    
    private float originalXScale;
    private float originalYScale;
    private float timeElapsedInBreath;

    // Start is called before the first frame update
    void Start()
    {
        originalXScale = transform.localScale.x;
        originalYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsedInBreath = (timeElapsedInBreath + Time.deltaTime) % breathDuration;
        // [0.0, 1.0]
        float breathPoint = timeElapsedInBreath / breathDuration;
        UpdateValues(breathPoint);
    }

    void UpdateValues(float breathPoint)
    {
        transform.localScale = new Vector3(
            Mathf.Sin(breathPoint * Mathf.PI * 2) * maxXScaleOffset + originalXScale,
            Mathf.Sin(breathPoint * Mathf.PI * 2) * maxYScaleOffset + originalYScale,
            transform.localScale.z
        );
    }
}
