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

    public TMP_Text scoreText;
    
    public void AddScore(int value)
    {
        score += value; 
        scoreText.text = score.ToString();
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
        AddScore(0);
    }
}
