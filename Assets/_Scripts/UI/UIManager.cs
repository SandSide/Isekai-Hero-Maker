using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}

    [Header("UIs")]
    public GameOverUI gameOverUI;
    public QuestUI questUI;
    public GameUI gameUI;
    public NPCDetailsUI npcDetailsUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        Configuration();
    }

    void Start()
    {
        ToggleUIElement(gameOverUI, false);
        ToggleUIElement(questUI, false);
        ToggleUIElement(gameUI, false);
        ToggleUIElement(npcDetailsUI, false);
    }

    public void Configuration()
    {
        GameEvents.Instance.onPlayerScoreChange += UpdateScore;
    }

    public void ToggleUIElement(IUIElement uiElement, bool show)
    {
        uiElement.ToggleUiElement(show);
    }

    public void UpdateScore(int score)
    {
        gameUI.UpdateScore(score);
    }

    public void UpdateTimer(float time)
    {
        gameUI.UpdateTimer(time);
    }

    public void ShowGameOverUI(int score)
    {
        gameOverUI.UpdateScore(score);

        ToggleUIElement(gameOverUI, true);
        ToggleUIElement(questUI, false);
        ToggleUIElement(gameUI, false);
        ToggleUIElement(npcDetailsUI, false);
    }

    public void UpdateNPCDetails(Person details)
    {
        npcDetailsUI.UpdateDetails(details);
    }
}
