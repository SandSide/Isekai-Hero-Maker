using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    private static QuestController _instance;

    [Header("Timer Options")]
    public float timer;
    public float defaultTimeForQuest;
    public bool questActive = false;

    public Quest currenQuest;

    [Header("Quest Options")]
    public int minAge;
    public int maxAge;

    public static QuestController Instance
    {
        get{ return _instance;}
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(_instance == null)
            _instance = this;
        else   
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        //     StartNewQuest();

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

    public void StartNewQuest()
    {
        currenQuest = QuestFactory.CreateQuest(minAge, maxAge);
        NPCController.speed++;
        StartTimer();
    }

    public void EvaluateQuestResult(Person personDetails)
    {
        if(currenQuest == null)
            return;

        int points = 0;

        points += AgeEvaluator.Evaluate(currenQuest.age, personDetails.age);
        points += PotentialEvaluator.Evaluate(currenQuest.potential, personDetails.potential);
        points += TraitEvaluator.Evaluate(currenQuest.trait, personDetails.trait);

        Debug.Log("Evalaution: " + points);
        StartNewQuest();
    }

    public void QuestOver()
    {
        Debug.Log("Game Over");
        questActive = false;
    }
}
