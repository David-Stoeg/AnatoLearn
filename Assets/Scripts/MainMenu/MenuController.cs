using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField] 
    private string backButtonScene = ""; // Scene to load with the Back button

    [SerializeField] 
    private string viewerButtonScene = ""; // Scene to load with the 3DViewer button

    private void OnEnable()
    {
        // Get the root visual element
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Find buttons by name
        Button exitButton = root.Q<Button>("Exit");
        Button switchSceneButton = root.Q<Button>("3DViewer"); // Button for switching to viewer scene
        Button backButton = root.Q<Button>("Back"); // Button for loading back scene

        // Assign the click events to the buttons
        if (exitButton != null)
        {
            exitButton.clicked += ExitApp;
        }

        if (switchSceneButton != null)
        {
            switchSceneButton.clicked += LoadViewerScene;
        }

        if (backButton != null)
        {
            backButton.clicked += LoadBackScene;
        }
    }

    // Function to load the scene for the 3DViewer button
    private void LoadViewerScene()
    {
        if (!string.IsNullOrEmpty(viewerButtonScene)) // Ensure scene name is set
        {
            SceneManager.LoadScene(viewerButtonScene);
        }
        else
        {
            Debug.LogWarning("Viewer scene name is empty! Please assign a scene in the Inspector.");
        }
    }

    // Function to load the scene for the Back button
    private void LoadBackScene()
    {
        if (!string.IsNullOrEmpty(backButtonScene)) // Ensure scene name is set
        {
            SceneManager.LoadScene(backButtonScene);
        }
        else
        {
            Debug.LogWarning("Back scene name is empty! Please assign a scene in the Inspector.");
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
