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
        // If player is alive...
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            timeElapsed += Time.deltaTime;
        }

        // If a full second has passed...
        if ((timeElapsed - Time.deltaTime) % 1f < timeElapsed % 1f)
        {
            SetTimerText();
        }
    }

    void SetTimerText()
    {
        int hours = Mathf.FloorToInt(timeElapsed / (60 * 60));
        int minutes = Mathf.FloorToInt(timeElapsed % (60 * 60) / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerTextComponent.text = "";
        
        if (hours < 10)
        {
            timerTextComponent.text += "0";
        }
        timerTextComponent.text += hours.ToString();

        timerTextComponent.text += ":";

        if (minutes < 10)
        {
            timerTextComponent.text += "0";
        }
        timerTextComponent.text += minutes.ToString();

        timerTextComponent.text += ":";

        if (seconds < 10)
        {
            timerTextComponent.text += "0";
        }
        timerTextComponent.text += seconds.ToString();
    }
}
