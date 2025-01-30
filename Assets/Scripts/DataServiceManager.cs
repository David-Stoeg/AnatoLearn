using UnityEngine;

public class DataServiceManager : MonoBehaviour
{
    public static DataServiceManager Instance { get; private set; }

    public DataService DataService { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeDataService();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeDataService()
    {
        DataService = new DataService("AnatoDb.db");
        DataService.CreateDB();
    }
}
