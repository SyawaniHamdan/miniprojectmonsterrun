﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpointice2 : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Calver")
        {
            SceneManager.LoadScene("SceneIce3");
        }
    }
}
