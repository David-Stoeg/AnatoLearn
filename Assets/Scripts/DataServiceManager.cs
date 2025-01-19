using UnityEngine;

public class DataServiceManager : MonoBehaviour
{
    // Die Singleton-Instanz
    public static DataServiceManager Instance { get; private set; }

    // Der zentral verwaltete DataService
    public DataService DataService { get; private set; }

    void Awake()
    {
        // Prüfen, ob es schon eine Instanz gibt
        if (Instance == null)
        {
            Instance = this; // Diese Instanz als Singleton setzen
            DontDestroyOnLoad(gameObject); // Objekt beim Szenenwechsel nicht zerstören
            InitializeDataService(); // Initialisierung des DataService
        }
        else
        {
            Destroy(gameObject); // Falls eine zweite Instanz entsteht, zerstören
        }
    }

    private void InitializeDataService()
    {
        DataService = new DataService("AnatoDb.db"); // Instanz erstellen
        DataService.CreateDB(); // Datenbank initialisieren
        Debug.Log("DataService wurde initialisiert.");
    }
}
