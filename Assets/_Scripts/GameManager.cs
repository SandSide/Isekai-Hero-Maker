using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    public QuestController questController;

    private bool isGameOver = false;

    public bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
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
}
