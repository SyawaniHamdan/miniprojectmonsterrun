using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public int prevLevel;
    public int nextLevel;

    public int prevScoree;
    public int totalScore;

    public void LoadGame()
    {
        prevLevel = Checkpoint.InstanceScene.returnPrevScene();

        if (prevLevel >= 13)
        {
            //GO TO LEADERBOARD
            //SceneManager.LoadScene(); 
        }
        else {
            SceneManager.LoadScene(prevLevel + 1); 
        }
    }

    public void retryLevel()
    {
        //after game over Retry
        prevLevel = Checkpoint.InstanceScene.returnPrevScene();

        AcessScoring.Instance.score = AcessScoring.Instance.scoreLevel;

        SceneManager.LoadScene(prevLevel);
        
    }

    public void retryLevel1()
    {
        //after game over Retry
        prevLevel = Checkpoint.InstanceScene.returnPrevScene();
        Debug.Log("PrevLevel : " + prevLevel);
        
        AcessScoring.Instance.score = AcessScoring.Instance.scoreLevel;

        SceneManager.LoadScene(prevLevel);

    }
}
