using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{

    [Header("Timer Options")]
    public float timer;
    public float defaultTimeForQuest;
    public bool questActive = false;

    public Quest currenQuest;

    [Header("Quest Options")]
    public int minAge;
    public int maxAge;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            StartNewQuest();

        if(questActive)
        {
            timer -= Time.deltaTime;

            if(timer < 0)
                QuestOver();
        }
    }

    public void StartTimer()
    {
        timer = defaultTimeForQuest;
        questActive = true;
    }

    void StartNewQuest()
    {
        currenQuest = QuestFactory.CreateQuest(minAge, maxAge);
        
        Debug.Log("age " + currenQuest.age);
        Debug.Log("potential " + currenQuest.potential);
        Debug.Log("trait " + currenQuest.trait);

        StartTimer();
    }

    public void EvaluateQuestResult()
    {
        
    }

    public void QuestOver()
    {
        Debug.Log("Game Over");
        questActive = false;
    }
}
