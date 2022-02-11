using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoretenenet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Calver"))
        {
            SoundManager.PlaySound("pCollect");
            AcessScoring.Instance.score += 10;
            Destroy(gameObject); 
        }
    }
}
