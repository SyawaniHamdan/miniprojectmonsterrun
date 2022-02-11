using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint InstanceScene;
    public int nextSceneLoad;
    public int currentScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (other.tag == "Calver")
        {
            //SceneManager.LoadScene("ScoreBoard");
            
            if(currentScene >= 5 && currentScene <= 13)
            {
                nextSceneLoad = 15;
                Debug.Log("Next Scene " + nextSceneLoad);
                Debug.Log("Current Scene " + currentScene);
                SceneManager.LoadScene(nextSceneLoad);
            }
            
        }
    }
    public void Awake()
    {
        if (InstanceScene == null)
        {
            InstanceScene = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public int returnPrevScene()
    {
        return currentScene;
    }
   
    
}
