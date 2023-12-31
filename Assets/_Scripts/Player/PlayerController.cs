using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance
    {
        get { return _instance; }
    }
    
    private int score = 0;
    public int Score 
    {
        get { return score; }
        set
        {
            score = value;
            GameEvents.Instance.PlayerScoreChange(score);
        }
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

    void Start()
    {
        Score = 0;
    }

    void Update()
    {
        
    }

    public void AddScore(int value)
    {
        Score += value; 
    }
}
