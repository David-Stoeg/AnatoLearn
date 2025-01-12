using UnityEngine;
using UnityEngine.UI;

public class FloatingMenu : MonoBehaviour
{
    public Button ActionButton;
    public Button InfoButton;
    public Button AnimationButton;
    public Button SearchButton;

    public GameObject AnimationSlider; // Der externe AnimationSlider
    public GameObject SearchBarCanvas; // Der externe SearchBar-Canvas


    private CanvasGroup infoCanvasGroup;
    private CanvasGroup animationCanvasGroup;
    private CanvasGroup searchCanvasGroup;

    private bool isMenuOpen = false; // Status des Menüs

    void Start()
    {
        // CanvasGroups initialisieren
        infoCanvasGroup = InfoButton.GetComponent<CanvasGroup>();
        animationCanvasGroup = AnimationButton.GetComponent<CanvasGroup>();
        searchCanvasGroup = SearchButton.GetComponent<CanvasGroup>();

        // Anfangszustand setzen (nur ActionButton sichtbar, AnimationSlider aus)
        CloseMenu();
        AnimationSlider.SetActive(false); // Der AnimationSlider ist am Anfang unsichtbar
        SearchBarCanvas.SetActive(false);


        // Button Listener setzen
        ActionButton.onClick.AddListener(ToggleMenu);
        InfoButton.onClick.AddListener(CloseMenuAndHideSlider);
        AnimationButton.onClick.AddListener(OpenAnimationSlider);
        SearchButton.onClick.AddListener(CloseMenuAndHideSlider);
        SearchButton.onClick.AddListener(OpenSearchBar);

    }

    // Öffnet oder schließt das Menü
    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;

        if (isMenuOpen)
        {
            ShowButtons();
        }
        else
        {
            CloseMenu();
        }
    }

    // Zeigt die zusätzlichen Buttons
    private void ShowButtons()
    {
        SetButtonState(infoCanvasGroup, true);
        SetButtonState(animationCanvasGroup, true);
        SetButtonState(searchCanvasGroup, true);
    }

    // Blendet alle Buttons außer ActionButton aus
    private void CloseMenu()
    {
        SetButtonState(infoCanvasGroup, false);
        SetButtonState(animationCanvasGroup, false);
        SetButtonState(searchCanvasGroup, false);
    }

    // Blendet den AnimationSlider ein und schließt das Menü, wenn AnimationButton geklickt wird
    private void OpenAnimationSlider()
    {
        CloseMenu(); // Schließt das Menü (versteckt die drei Buttons)
        AnimationSlider.SetActive(true); // Zeigt den AnimationSlider an
        SearchBarCanvas.SetActive(false);
    }

    private void OpenSearchBar()
    {
    CloseMenu(); // Menü schließen
    SearchBarCanvas.SetActive(true); // SearchBar anzeigen
    AnimationSlider.SetActive(false); // AnimationSlider sicherheitshalber ausblenden
    }


    // Menü schließen + AnimationSlider verstecken (wenn Info oder Search geklickt wird)
    private void CloseMenuAndHideSlider()
    {
        CloseMenu();
        AnimationSlider.SetActive(false);
        SearchBarCanvas.SetActive(false);
    }



    // Helferfunktion zum Setzen der Sichtbarkeit
    private void SetButtonState(CanvasGroup canvasGroup, bool state)
    {
        canvasGroup.alpha = state ? 1f : 0f;
        canvasGroup.interactable = state;
        canvasGroup.blocksRaycasts = state;
    }
}
