using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            //LoadGameButton.interactable = false;
        }
    }
    public void OnLoadGameClicked()
    {
        //Debug.Log("Load Game Clicked");
        //Load the next scene, which loads the game due to OnSceneLoaded() in the DataPersistenceManager
        SceneManager.LoadSceneAsync("SampleScene");
    }
}