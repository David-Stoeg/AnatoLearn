using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string backButtonScene = ""; // Scene to load with the Back button
    [SerializeField] private string viewerButtonScene = ""; // Scene to load with the 3DViewer button
    [SerializeField] private string humanExplorerScene = ""; // Scene to load with the Human Explorer button
    [SerializeField] private string animationsScene = ""; // Scene to load with the Animations button
    [SerializeField] private string quizScene = ""; // Scene to load with the Quiz button ✅

    private void OnEnable()
    {
        // Get the root visual element
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Find buttons by name
        Button exitButton = root.Q<Button>("Exit");
        Button switchSceneButton = root.Q<Button>("3DViewer"); 
        Button backButton = root.Q<Button>("Back");
        Button humanExplorerButton = root.Q<Button>("HumanExplore");
        Button animationsButton = root.Q<Button>("Animations");
        Button quizButton = root.Q<Button>("Quiz"); 

        // Assign the click events to the buttons
        if (exitButton != null) exitButton.clicked += ExitApp;
        if (switchSceneButton != null) switchSceneButton.clicked += LoadViewerScene;
        if (backButton != null) backButton.clicked += LoadBackScene;
        if (humanExplorerButton != null) humanExplorerButton.clicked += LoadHumanExplorerScene;
        if (animationsButton != null) animationsButton.clicked += LoadAnimationsScene;
        if (quizButton != null) quizButton.clicked += LoadQuizScene; 
    }

    // Function to load the scene for the 3DViewer button
    private void LoadViewerScene()
    {
        LoadScene(viewerButtonScene, "Viewer");
    }

    // Function to load the scene for the Back button
    private void LoadBackScene()
    {
        LoadScene(backButtonScene, "Back");
    }

    // Function to load the scene for the Human Explorer button
    private void LoadHumanExplorerScene()
    {
        LoadScene(humanExplorerScene, "Human Explorer");
    }

    // Function to load the scene for the Animations button
    private void LoadAnimationsScene()
    {
        LoadScene(animationsScene, "Animations");
    }

    // ✅ Function to load the scene for the Quiz button
    private void LoadQuizScene()
    {
        LoadScene(quizScene, "Quiz");
    }

    // Helper function to load scenes safely
    private void LoadScene(string sceneName, string sceneLabel)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning($"{sceneLabel} scene name is empty! Please assign a scene in the Inspector.");
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
