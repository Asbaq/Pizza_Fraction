using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneName;
    public int Count = 0;
    public TextMeshProUGUI Context;

    public void OnClick() 
    { 
         if(Count == 2)
         {
            SyncLoadScene();
         }
         else
         {
            Count++;
            Context.text = "Congo Stage " + (int)(Count+1) + " Complete";
         }
    }


    public void SyncLoadScene()
    {
        // Log a message for debugging 
        Debug.Log("Loading new scene...");

        // Load the scene synchronously by name
        SceneManager.LoadScene(SceneName);  // Replace with your scene name
    }
    public void Quit()
    {
        Application.Quit();  
    }
}
