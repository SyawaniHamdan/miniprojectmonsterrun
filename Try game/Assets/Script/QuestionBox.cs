using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBox : MonoBehaviour
{
    public GameObject pickupPrefab;
    //public GameObject mat;

    void HitZone()
    {
        Instantiate(pickupPrefab, transform.position + Vector3.up, transform.rotation);
        //transform.parent.GetComponent<Renderer>().material = mat;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Calver")
        {
            SoundManager.PlaySound("pBreak");
            HitZone();
        }
    }

}
