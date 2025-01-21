using UnityEngine;
using TMPro;  // TextMeshPro Namespace
using System.Collections.Generic;

public class Suche : MonoBehaviour
{
    public TMP_InputField searchInputField;  // Input Field Referenz
    private DataService ds;
    private string previousSearchText = "";

    void Start()
    {
        ds = DataServiceManager.Instance.DataService;

        // Event Listener hinzufügen
        searchInputField.onValueChanged.AddListener(OnSearchFieldChanged);
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
            var descriptions = ds.GetDescription(result.id);
            foreach (var desc in descriptions)
            {
                Debug.Log($"ID: {desc.id - 1}, Text: {desc.text}"); //Alle Descriptions
            }
            


        }
        
    }
}
