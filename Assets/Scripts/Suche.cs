using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using System.Collections.Generic;

public class Suche : MonoBehaviour
{
    public TMP_InputField searchInputField; 
    public GameObject suggestionPrefab;   
    public Transform suggestionsParent;  

    private DataService ds;              
    private string previousSearchText = "";

    void Start()
    {
        ds = DataServiceManager.Instance.DataService;

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

        foreach (Transform child in suggestionsParent)
        {
            Destroy(child.gameObject);
        }

        if (anatomicalStructures == null || !anatomicalStructures.GetEnumerator().MoveNext())
        {
            Debug.Log("Keine Ergebnisse gefunden!");
            return;
        }

        foreach (var result in anatomicalStructures)
        {
            Debug.Log($"ID: {result.id}, German: {result.german_name}, Latin: {result.latin_name}");

            GameObject suggestion = Instantiate(suggestionPrefab, suggestionsParent);

            TMP_Text suggestionText = suggestion.GetComponentInChildren<TMP_Text>();
            if (suggestionText != null)
            {
                suggestionText.text = $"{result.german_name}, {result.latin_name}";
            }

            Button suggestionButton = suggestion.GetComponent<Button>();
            if (suggestionButton != null)
            {
                suggestionButton.onClick.AddListener(() => OnSuggestionClicked(result));
            }
        }
    }

    // Event beim Klicken eines Vorschlags
    void OnSuggestionClicked(AnatomicalStructures result)
    {
        Debug.Log($"Ausgewählt: {result.german_name} ({result.latin_name})");

    }
}
