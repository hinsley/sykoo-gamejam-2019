using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    Text timerTextComponent;
    float timeElapsed = 0; 

    // Start is called before the first frame update
    void Start()
    {
        timerTextComponent = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        SetTimerText(timeElapsed);
    }

    void SetTimerText(float timeSeconds)
    {
        timerTextComponent.text = Mathf.Floor(timeSeconds).ToString();
    }
}
