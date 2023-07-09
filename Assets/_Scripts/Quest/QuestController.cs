using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestController : MonoBehaviour
{
    private static QuestController _instance;

    public Quest currenQuest;

    [Header("Timer Options")]
    public float timer;
    public float defaultTimeForQuest;
    public TMP_Text timerText;

    [Header("Quest Options")]
    public bool questActive = false;
    public int minAge;
    public int maxAge;

    [Header("Quest UI")]
    public TMP_Text ageText;
    public TMP_Text potentailText;
    public TMP_Text traitText;

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
        if(GameManager.Instance.IsGameOver)
            return;
            
        if(questActive)
        {
            timer -= Time.deltaTime;

            string temp = ((int)timer).ToString();
            timerText.SetText(temp);

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
        ageText.text = currenQuest.age.ToString();
        potentailText.text = currenQuest.potential.ToString();
        traitText.text = currenQuest.trait.ToString();
    }

    public void QuestOver()
    {
        GameManager.Instance.IsGameOver = true;
        questActive = false;
    }
}
