using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Suche : MonoBehaviour
{
    public TMP_InputField searchInputField;
    public GameObject suggestionPrefab;
    public Transform suggestionsParent;
    public GameObject scrollView;
    public GameObject fbxRoot; // Ziehe das Root-Objekt des FBX-Modells hierhin

    private DataService ds;
    private string previousSearchText = "";

    void Start()
    {
        ds = DataServiceManager.Instance.DataService;

        searchInputField.onValueChanged.AddListener(OnSearchFieldChanged);

        scrollView.SetActive(false);
        GetRenderableModels();
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

    void OnSuggestionClicked(AnatomicalStructures result)
    {
        Debug.Log($"Ausgewählt: {result.german_name} ({result.latin_name})");
        string displayText = result.german_name.Length > 30
            ? result.german_name.Substring(0, 27) + "..."
            : result.german_name;

        searchInputField.text = displayText;
        scrollView.SetActive(false);

        // Suche im FBX-Modell und passe Transparenz an
        ApplyTransparencyToFBX(result.latin_name);
    }

    void ApplyTransparencyToFBX(string targetModelName)
    {
        if (fbxRoot == null)
        {
            Debug.LogError("FBX Root Object ist nicht zugewiesen!");
            return;
        }

        Debug.Log($"Suche nach Modell: {targetModelName}");

        bool modelFound = false;

        string hardcodeModell = "XMSL_Muscle.003.L";

        // Iteriere durch alle Kinder von fbxRoot
        foreach (Transform child in fbxRoot.GetComponentsInChildren<Transform>(true))
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Logge, welche Renderer gefunden wurden
                Debug.Log($"Renderer gefunden für: {child.name}");

                // Überprüfe, ob der aktuelle Name dem gesuchten Modell entspricht
                if (child.name == hardcodeModell)
                {
                    Debug.Log($"Modell gefunden: {child.name}");
                    SetMaterialTransparency(renderer, 1.0f); // Voll sichtbar
                    modelFound = true;
                }
                else
                {
                    SetMaterialTransparency(renderer, 0.2f); // Halb transparent
                }
            }
        }

        if (!modelFound)
        {
            Debug.LogWarning($"Modell {targetModelName} wurde nicht gefunden.");
        }
    }

    // Setzt die Transparenz eines Renderers
    void SetMaterialTransparency(Renderer renderer, float alpha)
    {
        foreach (Material mat in renderer.materials)
        {
            Color color = mat.color;
            color.a = alpha;
            mat.color = color;

            // Stelle sicher, dass der Shader Transparenz unterstützt
            mat.SetFloat("_Mode", 2); // Transparent-Modus
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;
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

        // Iteriere durch alle Kinder von fbxRoot
        foreach (Transform child in fbxRoot.GetComponentsInChildren<Transform>(true))
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderableModels.Add(renderer);
                Debug.Log($"Renderbares Modell gefunden: {child.name}");
            }
        }

        return renderableModels;
    }
}
