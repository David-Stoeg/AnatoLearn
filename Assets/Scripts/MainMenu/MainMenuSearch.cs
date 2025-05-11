using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MainMenuSearch : MonoBehaviour
{
    public TMP_InputField searchInputField;
    public GameObject suggestionPrefab;
    public Transform suggestionsParent;
    public GameObject scrollView;

    private DataService ds;
    private string previousSearchText = "";

    void Start()
    {
        ds = DataServiceManager.Instance.DataService;

        // searchInputField.onValueChanged.AddListener(OnSearchFieldChanged);

        // scrollView.SetActive(false);
    }

    void OnSearchFieldChanged(string searchText)
    {
        if (searchText != previousSearchText)
        {
            Search(searchText);
            previousSearchText = searchText;

            if (string.IsNullOrEmpty(searchText))
            {
                scrollView.SetActive(false);
            }
            else
            {
                scrollView.SetActive(true);
            }
        }
    }

    void Search(string searchText)
    {
        var anatomicalStructures = ds.GetLiveSearchedModel(searchText);

        // Clear previous suggestions
        foreach (Transform child in suggestionsParent)
        {
            Destroy(child.gameObject);
        }

        // Handle no results
        if (anatomicalStructures == null || !anatomicalStructures.GetEnumerator().MoveNext())
        {
            GameObject noresult = Instantiate(suggestionPrefab, suggestionsParent);
            TMP_Text noresultText = noresult.GetComponentInChildren<TMP_Text>();
            noresultText.text = "Keine Ergebnisse gefunden.";
            return;
        }

        // Display suggestions
        foreach (var result in anatomicalStructures)
        {
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

    void OnSuggestionClicked(AnatomicalStructures result)
    {
        Debug.Log($"Ausgewählt: {result.german_name} ({result.latin_name})");
        string displayText = result.german_name.Length > 30
            ? result.german_name.Substring(0, 27) + "..."
            : result.german_name;

        // Set the selected term in the search bar
        searchInputField.text = displayText;
        scrollView.SetActive(false);

        // Pass the selected body part's name to the 3D viewer scene
        SceneData.SelectedBodyPartName = result.latin_name;

        // Load the 3D viewer scene
        SceneManager.LoadScene("3D-View_update");
    }
}
