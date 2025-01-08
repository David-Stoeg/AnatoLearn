using UnityEngine;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    // Diese Methode wird auf den Button-Click gesetzt
    public void GoToMainMenu()
    {
        // Der Name der Szene des Hauptmenüs
        string MainMenu = "MainMenu";
        
        // Szene laden
        SceneManager.LoadScene(MainMenu);
    }
}
