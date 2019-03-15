using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public int digits = 6;
    [System.NonSerialized]
    public int score = 0;

    Text scoreTextComponent;

    // Start is called before the first frame update
    void Start()
    {
        scoreTextComponent = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextComponent.text = score.ToString();
        while (scoreTextComponent.text.Length < digits)
        {
            scoreTextComponent.text = "0" + scoreTextComponent.text;
        }
    }
}
