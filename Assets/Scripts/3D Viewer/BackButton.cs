using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "MainMenu"; // Default to MainMenu

    public void GoToScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad)) // Ensure a scene name is set
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No scene name specified!");
        }
    }
}