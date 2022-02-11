using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    //public static int getScore;
    //Text score;
    public TMP_Text score;
    public int totalScore = 0; 
    public int currentScore = 0;
    public int prevScore = 0;

    //badges
    public Image badgeDisplay;
    public Sprite badge1; //beginner
    public Sprite badge2; //ammature
    public Sprite badge3;
    public Sprite badge4;

    public void SetBadge1(Sprite b)
    {
        badgeDisplay.sprite = b;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
        //score.text = AcessScoring.Instance.score.ToString();

        totalScore = AcessScoring.Instance.score;

        if (totalScore <= 0){
            AcessScoring.Instance.score = 0;
            totalScore = 0; 
        }
        //scoreLevel holds previous level's total score
        prevScore = AcessScoring.Instance.scoreLevel;

        currentScore = totalScore - prevScore;

        if (currentScore <= 0) { currentScore = 0; }

        AcessScoring.Instance.scoreLevel = totalScore;
        AcessScoring.Instance.curentLevelScore = currentScore;

        score.text = currentScore.ToString();


        Debug.Log("prev= " + prevScore + " total = " + totalScore + "currentScore= " + currentScore);
        //AcessScoring.Instance2.score = 0;

        if(currentScore < 20)
        {
            SetBadge1(badge1);
        }else if (currentScore < 50)
        {
            SetBadge1(badge2);
        }
        else if (currentScore < 90)
        {
            SetBadge1(badge3);
        }
        else if (currentScore >= 90)
        {
            SetBadge1(badge4);
        }


    }

    void Update()
    {
       
    }
}
