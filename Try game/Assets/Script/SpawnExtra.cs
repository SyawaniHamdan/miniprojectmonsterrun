using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExtra : MonoBehaviour
{
    public GameObject extra;

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Calver")
        {
            Debug.Log("spawn");

            Instantiate(extra, transform.position, Quaternion.identity);
        }
    }
}
