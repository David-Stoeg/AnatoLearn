using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SlideBarController : MonoBehaviour
{
    private VisualElement sliderHandle;        // Der bewegliche Kreis
    private VisualElement slideBar;            // Die Bar, auf der der Slider sich bewegt
    private VisualElement homeButton;          // Option 1: "Home"
    private VisualElement profileButton;       // Option 2: "Profile"
    private VisualElement settingsButton;      // Option 3: "Settings"

    private int currentOption = 0;             // Startoption: 0 = "Home"
    private string[] sceneNames = { "MainMenu", "Profile", "Preferences" }; // Szenennamen
    private float[] buttonPositions;           // Relativpositionen der Buttons auf der SlideBar

    private void Start()
    {
        // Zugriff auf die UI
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Referenzen holen
        slideBar = root.Q<VisualElement>("slideBar");
        sliderHandle = root.Q<VisualElement>("sliderHandle");
        homeButton = root.Q<VisualElement>("homeButton");
        profileButton = root.Q<VisualElement>("profileButton");
        settingsButton = root.Q<VisualElement>("settingsButton");

        // Relativpositionen der Buttons berechnen
        buttonPositions = new float[3];
        buttonPositions[0] = homeButton.resolvedStyle.left / slideBar.resolvedStyle.width;
        buttonPositions[1] = profileButton.resolvedStyle.left / slideBar.resolvedStyle.width;
        buttonPositions[2] = settingsButton.resolvedStyle.left / slideBar.resolvedStyle.width;

        // Setze den Handle auf die Startoption
        UpdateHandlePosition();

        // Ereignisse registrieren
        slideBar.RegisterCallback<PointerMoveEvent>(OnPointerMove);
        slideBar.RegisterCallback<PointerUpEvent>(OnPointerUp);
    }

    private void OnPointerMove(PointerMoveEvent evt)
    {
        // Mausposition relativ zur SlideBar
        Vector2 localPosition = evt.localPosition;
        float relativePosition = Mathf.Clamp(localPosition.x / slideBar.resolvedStyle.width, 0, 1);

        // Slider-Handle nur innerhalb der SlideBar bewegen
        sliderHandle.style.left = new Length(relativePosition * 100, LengthUnit.Percent);
    }

    private void OnPointerUp(PointerUpEvent evt)
    {
        // Mausposition relativ zur SlideBar
        Vector2 localPosition = evt.localPosition;
        float relativePosition = Mathf.Clamp(localPosition.x / slideBar.resolvedStyle.width, 0, 1);

        // Nächstgelegene Option bestimmen
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

        // Setze die neue Option und aktualisiere den Slider
        currentOption = closestOption;
        UpdateHandlePosition();

        // Szene wechseln
        ChangeScene();
    }

    private void UpdateHandlePosition()
    {
        // Handle-Position exakt an die aktuelle Option setzen
        sliderHandle.style.left = new Length(buttonPositions[currentOption] * 100, LengthUnit.Percent);
    }

    private void ChangeScene()
    {
        // Lade die entsprechende Szene basierend auf der aktuellen Option
        SceneManager.LoadScene(sceneNames[currentOption]);
    }
}
