using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcessScoring : MonoBehaviour
{
    public static AcessScoring Instance;
    //public static AcessScoring Instance2;

    public int score = 0;
    public int scoreLevel = 0;     // total score until prev level
    public int curentLevelScore = 0;  // only score on prev level

    public string MainName;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
    }
}
