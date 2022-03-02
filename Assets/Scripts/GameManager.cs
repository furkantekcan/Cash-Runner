using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    

    public static GameManager Instance { get; private set; }

    public bool gameOver;
    public bool isGameStarted;
    public bool isLevelFinished;

    public int score = 0;
    public int totalSore = 0;

    


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        isGameStarted = false;
        isLevelFinished = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore(int coinType)
    {
        if (coinType == 0)
        {
            score += 10;
        }

        else if (coinType == 1)
        {
            score += 20;
        }
    }


    public void SetScore()
    {
        score = 0;
    }

    public void SetGameFinished()
    {
        if (!isLevelFinished)
        {
            isLevelFinished = true;
        }

        else
        {
            isLevelFinished = false;
        }
    }


    
}
