using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelScripts : MonoBehaviour
{
    public void QuitGame ()
    {
        Application.Quit ();
    }
	
	public int mainMenu;

	public void LoadMain ()
	{
		SceneManager.LoadScene(mainMenu);
	}
}
