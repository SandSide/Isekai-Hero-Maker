using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public QuestController questController;

    private bool isGameOver = false;

    public bool IsGameOver
    {
        get { return isGameOver; }
        set
         { 
            isGameOver = value; 

            if(isGameOver)
                HandleGameOver();  
        }
    }
    
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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLevel());
    }

    public IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(5f);
        questController.StartNewQuest();
        UIManager.Instance.ToggleUIElement(UIManager.Instance.gameUI, true);
        UIManager.Instance.ToggleUIElement(UIManager.Instance.questUI, true);
    }

    public void HandleGameOver()
    {
        AudioManager.instance.Play("game over");
        UIManager.Instance.ShowGameOverUI(PlayerController.Instance.Score);
    }
}
