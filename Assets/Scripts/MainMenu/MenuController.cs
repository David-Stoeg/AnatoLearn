using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField] 
    private string sceneToLoad = ""; // Field to specify scene name in Inspector

    private void OnEnable()
    {
        // Get the root visual element
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Find buttons by name
        Button exitButton = root.Q<Button>("Exit");
        Button switchSceneButton = root.Q<Button>("3DViewer"); // Button for switching scenes

        // Assign the click events to the buttons
        if (exitButton != null)
        {
            exitButton.clicked += ExitApp;
        }

        if (switchSceneButton != null)
        {
            switchSceneButton.clicked += LoadScene;
        }
    }

    // Function to load the specified scene
    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad)) // Ensure sceneToLoad is set
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name is empty! Please assign a scene in the Inspector.");
        }
    }

    // Function to exit the application
    private void ExitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in the editor
#else
        Application.Quit(); // Exits the app on a device
#endif
    }
}
