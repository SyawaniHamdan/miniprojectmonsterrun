using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Calver"))
        {
            Debug.Log("get fruit");
            Destroy(gameObject);
            score.calcCoin += 10;
        }
    }
}
