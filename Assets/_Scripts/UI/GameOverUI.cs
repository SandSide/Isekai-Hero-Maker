using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gameOverView;
    public TMP_Text scoreText;

    public void Show(int score)
    {
        scoreText.text = "Score: " + PlayerController.Instance.Score.ToString();
        gameOverView.SetActive(true);
    }
}
