using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; private set; }

    public GameEvents()
    {
        if(Instance == null)
            Instance = this;
        else   
        {
            Destroy(gameObject);
            return;
        }
    }

    public event Action<NPCController> onNPCDied;
    public void NPCDied(NPCController npc)
    {
        if(onNPCDied != null)
            onNPCDied?.Invoke(npc);
    }

    public event Action<int> onPlayerScoreChange;
    public void PlayerScoreChange(int score)
    {
        if(onPlayerScoreChange != null)
            onPlayerScoreChange?.Invoke(score);
    }

    public event Action<Person> onDisplayPersonChange;
    public void DisplayPersonChange(Person person)
    {
        onDisplayPersonChange?.Invoke(person);
    }
}
