using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public QuestController questController;

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
