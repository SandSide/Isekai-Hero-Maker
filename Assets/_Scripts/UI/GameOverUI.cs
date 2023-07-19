using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : UIElementBase
{
    [Header("UI Elements")]
    public TMP_Text scoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + PlayerController.Instance.Score.ToString();
    }
}
