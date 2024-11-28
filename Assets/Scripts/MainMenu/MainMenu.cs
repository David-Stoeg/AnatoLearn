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
    private string[] sceneNames = { "MainMenu", "Profile", "Settings" }; // Szenennamen
    private float[] buttonPositions;           // Relativpositionen der Buttons auf der SlideBar
    private float slideBarWidth;               // Breite der SlideBar
    private Vector2 touchStartPos;             // Startposition des Fingers (oder Maus) beim Wischen
    private bool isSwiping = false;            // Flag, ob eine Swipe-Geste aktuell läuft
    private bool initialized = false;          // Verhindert doppelte Initialisierung

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

        // Ereignisse registrieren
        slideBar.RegisterCallback<PointerDownEvent>(OnPointerDown); // Start des Wischens
        slideBar.RegisterCallback<PointerUpEvent>(OnPointerUp);     // Ende des Wischens
        slideBar.RegisterCallback<PointerMoveEvent>(OnPointerMove); // Um das Ziehen zu verhindern
    }

    private void LateUpdate()
    {
        // Initialisierung durchführen, wenn noch nicht geschehen
        if (!initialized && slideBar.resolvedStyle.width > 0)
        {
            InitializeSlider();
            initialized = true;
        }
    }

    private void InitializeSlider()
    {
        // Breite der SlideBar erfassen
        slideBarWidth = slideBar.resolvedStyle.width;

        // Button-Positionen relativ zur SlideBar berechnen
        buttonPositions = new float[3];
        buttonPositions[0] = homeButton.resolvedStyle.left / slideBarWidth;
        buttonPositions[1] = profileButton.resolvedStyle.left / slideBarWidth;
        buttonPositions[2] = settingsButton.resolvedStyle.left / slideBarWidth;

        // Setze den Slider-Handle auf die aktuelle Option
        UpdateHandlePosition();
    }

    private void OnPointerDown(PointerDownEvent evt)
    {
        // Speichern der Startposition beim Wischen
        touchStartPos = evt.localPosition;
        isSwiping = true;
    }

    private void OnPointerUp(PointerUpEvent evt)
    {
        if (!isSwiping)
            return;

        // Berechne den Unterschied in der x-Achse zwischen Start- und Endposition
        float swipeDistance = evt.localPosition.x - touchStartPos.x;

        // Wenn die Swipe-Distanz groß genug ist, reagiere auf das Wischen
        if (Mathf.Abs(swipeDistance) > 50) // 50 ist der Schwellenwert für einen gültigen Swipe
        {
            // Wische nach rechts oder links
            int direction = swipeDistance > 0 ? 1 : -1; // Nach rechts (+1) oder nach links (-1)
            currentOption = Mathf.Clamp(currentOption + direction, 0, buttonPositions.Length - 1);

            // Handle auf die neue Position setzen und Szene wechseln
            UpdateHandlePosition();
            ChangeScene();
        }

        // Rücksetzen
        isSwiping = false;
    }

    private void OnPointerMove(PointerMoveEvent evt)
    {
        // Verhindern, dass der Slider mit der Maus/Finger folgt, während man swiped
        if (isSwiping)
        {
            evt.StopPropagation(); // Dies stoppt die Weiterleitung des PointerMove-Events, sodass es nicht auf das Slider-Element angewendet wird.
        }
    }

    private void UpdateHandlePosition()
    {
        // Setze den Handle auf die aktuelle Option
        float targetPosition = buttonPositions[currentOption] * 100;
        sliderHandle.style.left = new Length(targetPosition, LengthUnit.Percent);

        // Debug-Log für die Position
        Debug.Log($"Slider Handle Position Updated: {targetPosition}%");
    }

    private void ChangeScene()
    {
        // Lade die entsprechende Szene basierend auf der aktuellen Option
        string sceneToLoad = sceneNames[currentOption];
        Debug.Log($"Changing Scene to: {sceneToLoad}");
        SceneManager.LoadScene(sceneToLoad);
    }
}
