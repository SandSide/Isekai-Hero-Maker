using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}

    [Header("UIs")]
    public GameOverUI gameOverUI;
    public QuestUI questUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowGameOverUI(int score)
    {
        gameOverUI.Show(score);
    }
}
