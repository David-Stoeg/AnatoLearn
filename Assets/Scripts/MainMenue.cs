using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


//3D-VIEWER BUTTON
public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        
        var root = GetComponent<UIDocument>().rootVisualElement;

        
        var button = root.Q<Button>("3DViewer"); 

        button.clicked += () =>
        {
            SceneManager.LoadScene("3D-View"); 
        };
    }
}

//SLIDER
public class SlideBarController : MonoBehaviour
{
    private VisualElement slideBar;  
    private VisualElement sliderHandle;                  
    private VisualElement homeButton;          
    private VisualElement profileButton;       
    private VisualElement settingsButton;      

    private int currentOption = 0;             // Startoption: 0 = "Home", 1 = "Profile", 2 = "Settings"
    private string[] sceneNames = { "MainMenu", "Profile", "Preferences" }; // Szenennamen

    private float[] buttonPositions;           // Positionen der Buttons auf der SlideBar

    private void Start()
    {
        // Zugriff auf die UI
        var root = GetComponent<UIDocument>().rootVisualElement;

        // SlideBar und Handle finden
        slideBar = root.Q<VisualElement>("slideBar");
        sliderHandle = root.Q<VisualElement>("sliderHandle");

        // Buttons finden (homeButton, profileButton, settingsButton)
        homeButton = root.Q<VisualElement>("homeButton");
        profileButton = root.Q<VisualElement>("profileButton");
        settingsButton = root.Q<VisualElement>("settingsButton");

        // Berechne die Positionen der Buttons relativ zur SlideBar
        buttonPositions = new float[3];
        buttonPositions[0] = homeButton.resolvedStyle.left / slideBar.resolvedStyle.width;
        buttonPositions[1] = profileButton.resolvedStyle.left / slideBar.resolvedStyle.width;
        buttonPositions[2] = settingsButton.resolvedStyle.left / slideBar.resolvedStyle.width;

        // Setze den Handle an die Position der aktuellen Option (initial "Home")
        UpdateHandlePosition();

        // Registriere Callback für das Ziehen des Sliders
        slideBar.RegisterCallback<PointerMoveEvent>(OnPointerMove);
        slideBar.RegisterCallback<PointerUpEvent>(OnPointerUp);
    }

    private void OnPointerMove(PointerMoveEvent evt)
    {
        // Berechne die neue Position des Handles basierend auf der Mausbewegung
        Vector2 localPosition = evt.localPosition;
        float relativePosition = Mathf.Clamp(localPosition.x / slideBar.resolvedStyle.width, 0, 1);

        // Bewege den Handle visuell entlang der Slide Bar
        sliderHandle.style.left = new Length(relativePosition * 100, LengthUnit.Percent);
    }

    private void OnPointerUp(PointerUpEvent evt)
    {
        // Berechne die relative Position, wo der Handle nach oben gezogen wurde
        Vector2 localPosition = evt.localPosition;
        float relativePosition = Mathf.Clamp(localPosition.x / slideBar.resolvedStyle.width, 0, 1);

        // Bestimme, welche Option am nächsten ist
        float closestDistance = float.MaxValue;
        int closestOption = currentOption;

        for (int i = 0; i < buttonPositions.Length; i++)
        {
            float distance = Mathf.Abs(relativePosition - buttonPositions[i]);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestOption = i;
            }
        }

        // Setze die aktuelle Option und aktualisiere die Handle-Position
        currentOption = closestOption;
        UpdateHandlePosition();

        // Lade die Szene basierend auf der aktuellen Option
        ChangeScene();
    }

    private void UpdateHandlePosition()
    {
        // Setze den Handle an die Position des aktuellen Buttons
        sliderHandle.style.left = new Length(buttonPositions[currentOption] * 100, LengthUnit.Percent);
    }

    private void ChangeScene()
    {
        // Lade die entsprechende Szene basierend auf der aktuellen Option
        SceneManager.LoadScene(sceneNames[currentOption]);
    }
}
