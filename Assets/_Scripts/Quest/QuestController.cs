using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestController : MonoBehaviour
{
    public static QuestController Instance { get; private set; }
    
    [Header("Timer Options")]
    public float timer;
    public float defaultTimeForQuest;

    [Header("Quest Options")]
    public bool questActive = false;
    public int minAge;
    public int maxAge;

    public Quest currentQuest;
    public Quest CurrentQuest 
    { 
        get { return currentQuest;}
        set 
        {
            currentQuest = value;
            HandleNewQuest();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            GameEvents.Instance.onNPCDied += EvaluateQuestResult;
        }
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

    private void OnDestroy()
    {
        GameEvents.Instance.onNPCDied -= EvaluateQuestResult;
    }

    public void StartTimer()
    {
        timer = defaultTimeForQuest;
        questActive = true;
    }

    public void StartNewQuest()
    {
        CurrentQuest = QuestFactory.CreateQuest(minAge, maxAge);
        StartTimer();
    }

    public void EvaluateQuestResult(NPCController npc)
    {
        if(CurrentQuest == null)
            return;

        Person personDetails = npc.npcDetails;

        int points = 0;

        points += AgeEvaluator.Evaluate(CurrentQuest.age, personDetails.age);
        points += PotentialEvaluator.Evaluate(CurrentQuest.potential, personDetails.potential);
        points += TraitEvaluator.Evaluate(CurrentQuest.trait, personDetails.trait);

        PlayerController.Instance.AddScore(points);
        StartNewQuest();
    }

    public void HandleNewQuest()
    {
        //NPCController.speed = Mathf.Min(NPCController.speed + 1, 5);
        UIManager.Instance.questUI.UpdateUIContent(CurrentQuest);
    }

    public void QuestOver()
    {
        questActive = false;
        GameManager.Instance.IsGameOver = true;
    }
}
