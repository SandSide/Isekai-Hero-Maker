using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{

    [Header("Timer Options")]
    public float timer;
    public float timeForQuest;

    public Quest currenQuest;

    [Header("Quest Options")]
    public int minAge;
    public int maxAge;

    // Start is called before the first frame update
    void Start()
    {
        CreateNewQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            CreateNewQuest();
    }


    void Init()
    {

    }

    void CreateNewQuest()
    {
        currenQuest = QuestFactory.CreateQuest(minAge, maxAge);

        Debug.Log("age " + currenQuest.age);
        Debug.Log("potential " + currenQuest.potential);
        Debug.Log("trait " + currenQuest.trait);
    }
}
