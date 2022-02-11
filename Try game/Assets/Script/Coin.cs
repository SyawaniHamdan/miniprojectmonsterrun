using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Calver"))
        {
            Debug.Log("get coin");
            Destroy(gameObject);
            score.calcCoin += 10;
        }
    }
    // Start is called before the first frame update
}
