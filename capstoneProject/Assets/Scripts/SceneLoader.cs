using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button nextSceneButton;
    public string nextSceneName;

    private void Start()
    {
        // Attach a method to be called when the button is clicked
        nextSceneButton.onClick.AddListener(LoadNextScene);
    }

    void LoadNextScene()
    {
        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
