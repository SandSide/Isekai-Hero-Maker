using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    public QuestController questController;

    public GameObject gameOverView;
    public TMP_Text scoreText;

    private bool isGameOver = false;

    public bool IsGameOver
    {
        get { return isGameOver; }
        set
         { 
            isGameOver = value; 

            if(isGameOver)
            {
                DisplayGameOverView();  
                AudioManager.instance.Play("game over");
            }

        }
    }
    
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(5f);
        questController.StartNewQuest();
    }

    public void DisplayGameOverView()
    {
        gameOverView.SetActive(true);
        scoreText.text = "Score: " + PlayerController.Instance.Score.ToString();
    }
}
