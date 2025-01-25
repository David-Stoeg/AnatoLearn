using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class HumanExplore : MonoBehaviour
{
    public TMP_InputField searchInputField;
    public GameObject suggestionPrefab;
    public Transform suggestionsParent;
    public GameObject scrollView;
    public GameObject fbxRoot;

    private DataService ds;
    private string previousSearchText = "";

    void Start()
    {
        try
        {
            ds = DataServiceManager.Instance.DataService;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Fehler bei der Initialisierung der Datenbank: {ex.Message}");
            return;
        }

        searchInputField.onValueChanged.AddListener(OnSearchFieldChanged);
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
                List<Renderer> renderableModels = GetRenderableModels();
                foreach (var renderer in renderableModels)
                {
                    SetMaterialTransparency(renderer, 1.0f);
                }
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

        foreach (Transform child in suggestionsParent)
        {
            Destroy(child.gameObject);
        }

        if (anatomicalStructures == null || !anatomicalStructures.GetEnumerator().MoveNext())
        {
            GameObject noresult = Instantiate(suggestionPrefab, suggestionsParent);
            TMP_Text noresultText = noresult.GetComponentInChildren<TMP_Text>();
            noresultText.text = "Keine Ergebnisse gefunden.";
            return;
        }


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

    List<Renderer> GetRenderableModels()
    {
        List<Renderer> renderableModels = new List<Renderer>();

        if (fbxRoot == null)
        {
            Debug.LogError("FBX Root Object ist nicht zugewiesen!");
            return renderableModels;
        }

        foreach (Transform child in fbxRoot.GetComponentsInChildren<Transform>(true))
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderableModels.Add(renderer);
            }
        }

        return renderableModels;
    }

    void OnSuggestionClicked(AnatomicalStructures result)
    {
        Debug.Log($"Ausgewählt: {result.german_name} ({result.latin_name})");
        string displayText = result.german_name.Length > 30
            ? result.german_name.Substring(0, 27) + "..."
            : result.german_name;

        searchInputField.text = displayText;
        scrollView.SetActive(false);

        
    }

    void SetMaterialTransparency(Renderer renderer, float alpha)
    {
        foreach (Material mat in renderer.materials)
        {
            Color color = mat.color;
            color.a = alpha;
            mat.color = color;
            mat.SetFloat("_Mode", 2);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;
        }
    }

}



