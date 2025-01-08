using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FloatingMenu : MonoBehaviour
{
    public Button ActionButton; // Hauptbutton
    public Button InfoButton; // Info-Button
    public Button AnimationButton; // Animation-Button
    public Button SearchButton; // Such-Button

    public GameObject AnimationSlider; // Das UI-Element für den Animation-Slider

    public float animationDuration = 0.3f; // Dauer der Animation in Sekunden

    private bool isMenuOpen = false; // Status des Menüs
    private bool isAnimationMenuActive = false; // Status des Animation-Dialogs

    private CanvasGroup infoCanvasGroup;
    private CanvasGroup animationCanvasGroup;
    private CanvasGroup searchCanvasGroup;

    void Start()
    {
        // CanvasGroups initialisieren
        infoCanvasGroup = InfoButton.GetComponent<CanvasGroup>();
        animationCanvasGroup = AnimationButton.GetComponent<CanvasGroup>();
        searchCanvasGroup = SearchButton.GetComponent<CanvasGroup>();

        // Sub-Buttons und AnimationSlider standardmäßig unsichtbar machen
        SetButtonState(infoCanvasGroup, false);
        SetButtonState(animationCanvasGroup, false);
        SetButtonState(searchCanvasGroup, false);
        AnimationSlider.SetActive(false); // AnimationSlider ist zu Beginn unsichtbar

        // ActionButton Listener hinzufügen
        ActionButton.onClick.AddListener(ToggleMenu);

        // Listener für die anderen Buttons
        InfoButton.onClick.AddListener(CloseMenu);
        AnimationButton.onClick.AddListener(OpenAnimationSlider);
        SearchButton.onClick.AddListener(CloseMenu);
    }

    // Öffnet oder schließt das Menü
    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;

        if (isMenuOpen)
        {
            StartCoroutine(AnimateButtons(true)); // Menü anzeigen
        }
        else
        {
            StartCoroutine(AnimateButtons(false)); // Menü verstecken
        }
    }

    // Zeigt/Versteckt die Sub-Buttons
    IEnumerator AnimateButtons(bool open)
    {
        // Sub-Buttons aktivieren, wenn Menü geöffnet wird
        if (open)
        {
            SetButtonState(infoCanvasGroup, true);
            SetButtonState(animationCanvasGroup, true);
            SetButtonState(searchCanvasGroup, true);
        }

        // Starte Animation
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsedTime / animationDuration); // Smooth Animation

            infoCanvasGroup.alpha = open ? t : 1 - t;
            animationCanvasGroup.alpha = open ? t : 1 - t;
            searchCanvasGroup.alpha = open ? t : 1 - t;

            yield return null;
        }

        // Sub-Buttons deaktivieren, wenn Menü geschlossen wird
        if (!open)
        {
            SetButtonState(infoCanvasGroup, false);
            SetButtonState(animationCanvasGroup, false);
            SetButtonState(searchCanvasGroup, false);
        }
    }

    // Zeigt den AnimationSlider an, wenn der AnimationButton geklickt wird
    private void OpenAnimationSlider()
    {
        if (!isAnimationMenuActive)
        {
            AnimationSlider.SetActive(true); // AnimationSlider sichtbar machen
            isAnimationMenuActive = true;
        }
        else
        {
            AnimationSlider.SetActive(false); // AnimationSlider ausblenden
            isAnimationMenuActive = false;
        }
    }

    // Schließt das Menü bei Klick auf Info oder Search Button
    private void CloseMenu()
    {
        if (isMenuOpen)
        {
            isMenuOpen = false;
            StartCoroutine(AnimateButtons(false)); // Sub-Buttons ausblenden
        }
    }

    private void SetButtonState(CanvasGroup canvasGroup, bool state)
    {
        canvasGroup.alpha = state ? 1f : 0f;
        canvasGroup.interactable = state;
        canvasGroup.blocksRaycasts = state;
    }
}
