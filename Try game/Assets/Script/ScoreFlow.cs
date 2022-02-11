using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreFlow : MonoBehaviour
{

    //public static int totalCoin = 0;

    public TMP_Text myScoreText;
    public int score;
    void Start()
    {
        StartCoroutine(spawnTile());
    }


    void Update()
    {
        
    }

     IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);


        score = AcessScoring.Instance.score - AcessScoring.Instance.scoreLevel;

        if (score <= 0) { score = 0; }

        Debug.Log("total = " + AcessScoring.Instance.score + " prev Level = " + AcessScoring.Instance.scoreLevel);
        myScoreText.text = score.ToString(); 
        StartCoroutine(spawnTile());
          
    }

}
