using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestController : MonoBehaviour
{
    public static QuestController Instance {get; private set;}
    public Quest currenQuest;

    [Header("Timer Options")]
    public float timer;
    public float defaultTimeForQuest;

    [Header("Quest Options")]
    public bool questActive = false;
    public int minAge;
    public int maxAge;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else   
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsGameOver)
            return;
            
        if(questActive)
        {
            timer -= Time.deltaTime;
            UIManager.Instance.UpdateTimer(timer);

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
        NPCController.speed = Mathf.Min(NPCController.speed + 1, 5);

        UpdateQuestView();
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

        PlayerController.Instance.AddScore(points);
        StartNewQuest();
    }

    public void UpdateQuestView()
    {
        UIManager.Instance.questUI.UpdateUIContent(currenQuest);
    }

    public void QuestOver()
    {
        questActive = false;
        GameManager.Instance.IsGameOver = true;
    }
}
