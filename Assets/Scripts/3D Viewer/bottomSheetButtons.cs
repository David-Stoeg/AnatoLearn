using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    // Referenzen zu den Sprites für aktiv und inaktiv
    public Sprite activeSprite;
    public Sprite inactiveSprite;

    // Interne Zustandsvariable
    private bool isActive = false;

    // Referenz zum Image-Component
    private Image buttonImage;

    void Start()
    {
        // Hole das Image-Component des Buttons
        buttonImage = GetComponent<Image>();

        // Setze den initialen Zustand (deaktiviert)
        UpdateButtonImage();
    }

    // Methode, die beim Klicken des Buttons aufgerufen wird
    public void ToggleState()
    {
        // Ändere den Zustand
        isActive = !isActive;

        // Aktualisiere das Bild basierend auf dem neuen Zustand
        UpdateButtonImage();
    }

    private void UpdateButtonImage()
    {
        // Setze das Bild abhängig vom Zustand
        buttonImage.sprite = isActive ? activeSprite : inactiveSprite;
    }
}
