using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : UIElementBase
{
    [Header("UI Elements")]
    public TMP_Text timerText;
    public TMP_Text scoreText;

    public void Awake()
    {
        scoreText.text = "Score: 0";
        timerText.text = string.Empty;    
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateTimer(float time)
    {
        timerText.text = time.ToString("0.00");
    }
}
