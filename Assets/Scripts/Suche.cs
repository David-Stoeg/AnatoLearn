using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Suche : MonoBehaviour
{
    public string searchField = "la"; 
    private DataService ds;
    private string previousSearchText = "";

    void Start()
    {
       
        ds = new DataService("AnatoDb.db");
        ds.CreateDB();

        OnSearchFieldChanged(searchField);
        //searchField.onValueChanged.AddListener(OnSearchFieldChanged);
    }

    void OnSearchFieldChanged(string searchText)
    {
        
        if (searchText != previousSearchText)
        {
            Search(searchText);
            previousSearchText = searchText;
        }
    }

    void Search(string searchText)
    {
        
        var anatomicalStructures = ds.GetLiveSearchedModel(searchText);

        
        if (anatomicalStructures == null || !anatomicalStructures.GetEnumerator().MoveNext())
        {
            Debug.Log("Keine Ergebnisse gefunden!");
            return;
        }


        foreach (var result in anatomicalStructures)
        {
            Debug.Log($"ID: {result.id}, German: {result.german_name}, Latin: {result.latin_name}");
        }


    }
}
