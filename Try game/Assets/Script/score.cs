using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    public static int calcCoin;
    Text calcCoinText;

    // Start is called before the first frame update
    void Start()
    {
        calcCoin = 0;
        calcCoinText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        calcCoinText.text = calcCoin.ToString();

    }

    
}
