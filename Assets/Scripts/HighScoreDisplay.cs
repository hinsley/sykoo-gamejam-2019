using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
    public GameObject scoreDisplay;
    public int digits;

    ScoreDisplay scoreDisplayScript;
    Text highScoreText;
    int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplayScript = scoreDisplay.GetComponent<ScoreDisplay>();
        highScoreText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreDisplayScript.score > highScore)
        {
            highScore = scoreDisplayScript.score;
        }

        highScoreText.text = highScore.ToString();
        while (highScoreText.text.Length < digits)
        {
            highScoreText.text = "0" + highScoreText.text;
        }
    }
}
