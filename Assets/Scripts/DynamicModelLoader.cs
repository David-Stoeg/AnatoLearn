using UnityEngine;
using System.Collections.Generic;

public class DynamicModelLoader : MonoBehaviour
{
    public string AnatoModelPath; // Pfad relativ zu Resources

    void Start()
    {
        LoadFBXModel();
    }

    void LoadFBXModel()
    {
        var ds = new DataService("AnatoDb.db");
        ds.CreateDB();

        var models3D = ds.GetModels_3D();

        

        if (models3D == null)
        {
            Debug.LogError("models3D ist NULL! Prüfe die Datenbankverbindung oder die Abfrage.");
            return;
        }

        Debug.Log("Anzahl der Modelle: " + models3D.GetType());
        ToConsole(models3D);

        // Modell aus Resources laden
        GameObject fbxModel = Resources.Load<GameObject>(AnatoModelPath);
        if (fbxModel != null)
        {
            Instantiate(fbxModel, transform.position, Quaternion.identity);
            Debug.Log("FBX Modell erfolgreich geladen: " + AnatoModelPath);
        }
        else
        {
            Debug.LogError("FBX Modell konnte nicht geladen werden. Pfad: " + AnatoModelPath);
        }
    }

    private void ToConsole(IEnumerable<Models_3D> modelsList)
    {
        foreach (var model in modelsList)
        {
            ToConsole(model.ToString());
            AnatoModelPath = model.model_path;
        }
    }

    private void ToConsole(string message)
    {
        Debug.Log(message);
    }
}
