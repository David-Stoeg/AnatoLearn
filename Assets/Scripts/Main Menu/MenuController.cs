using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string backButtonScene = "";
    [SerializeField] private string viewerButtonScene = "";
    [SerializeField] private string humanExplorerScene = "";
    [SerializeField] private string animationsScene = "";
    [SerializeField] private GameObject challengePanel;

    private void Update()
    {
        // Check for back button press (Escape key on Android)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitApp();  // Exit the app immediately on back swipe
        }
    }

    public void LoadViewerScene() => LoadScene(viewerButtonScene, "Viewer");

    public void LoadBackScene() => LoadScene(backButtonScene, "Back");

    public void LoadHumanExplorerScene() => LoadScene(humanExplorerScene, "Human Explorer");

    public void LoadAnimationsScene() => LoadScene(animationsScene, "Animations");

    public void ShowQuizPanel()
    {
        if (challengePanel != null)
        {
            challengePanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Quiz Panel is not assigned!");
        }
    }

    public void HideQuizPanel()
    {
        if (challengePanel != null)
        {
            challengePanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Quiz Panel is not assigned!");
        }
    }

    public void ExitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

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
}
