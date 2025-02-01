using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField] 
    private string backButtonScene = ""; // Scene to load with the Back button

    [SerializeField] 
    private string viewerButtonScene = ""; // Scene to load with the 3DViewer button

    [SerializeField]
    private string humanExplorerScene = ""; // Scene to load with the Human Explorer button

    [SerializeField]
    private string animationsScene = ""; // Scene to load with the Animations button

    private void OnEnable()
    {
        // Get the root visual element
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Find buttons by name
        Button exitButton = root.Q<Button>("Exit");
        Button switchSceneButton = root.Q<Button>("3DViewer"); // Button for switching to viewer scene
        Button backButton = root.Q<Button>("Back"); // Button for loading back scene
        Button humanExplorerButton = root.Q<Button>("HumanExplore"); // Button for Human Explorer scene
        Button animationsButton = root.Q<Button>("Animations"); // Button for Animations scene (without hashtag)

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

        if (humanExplorerButton != null)
        {
            humanExplorerButton.clicked += LoadHumanExplorerScene;
        }

        if (animationsButton != null)
        {
            animationsButton.clicked += LoadAnimationsScene; // Add the event for the Animations button
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

    // Function to load the scene for the Human Explorer button
    private void LoadHumanExplorerScene()
    {
        if (!string.IsNullOrEmpty(humanExplorerScene)) // Ensure scene name is set
        {
            SceneManager.LoadScene(humanExplorerScene);
        }
        else
        {
            Debug.LogWarning("Human Explorer scene name is empty! Please assign a scene in the Inspector.");
        }
    }

    // Function to load the scene for the Animations button
    private void LoadAnimationsScene()
    {
        if (!string.IsNullOrEmpty(animationsScene)) // Ensure scene name is set
        {
            SceneManager.LoadScene(animationsScene);
        }
        else
        {
            Debug.LogWarning("Animations scene name is empty! Please assign a scene in the Inspector.");
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
