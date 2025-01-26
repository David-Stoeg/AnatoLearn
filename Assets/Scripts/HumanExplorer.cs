using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class HumanExplore : MonoBehaviour
{
    public TMP_InputField searchInputField;
    public GameObject suggestionPrefab;
    public Transform suggestionsParent;
    public GameObject scrollView;
    public GameObject fbxRoot;
    public GameObject ExploreWindow;
    public Button nextButton;
    public Button previousButton;
    public Button exploreButton;

    private DataService ds;
    private List<Renderer> renderableModels;
    private int currentModelIndex = 0;

    public TMP_Text centerText;
    public TMP_Text leftText;
    public TMP_Text rightText;
    public TMP_Text descriptionText;


    void Start()
    {
        ds = DataServiceManager.Instance.DataService;
        renderableModels = GetRenderableModels();

        if (!string.IsNullOrEmpty(SceneData.RendererName))
        {
            Debug.Log($"Empfangener Renderer-Name: {SceneData.RendererName}");

            for (int i = 0; i < renderableModels.Count; i++)
            {
                if (renderableModels[i].gameObject.name.Contains(SceneData.RendererName, System.StringComparison.OrdinalIgnoreCase))
                {
                    currentModelIndex = i;
                    ShowModelByIndex(currentModelIndex);
                    break;
                }
            }
        }
        else
        {
            Debug.LogWarning("Kein Renderer-Name verf�gbar.");
        }

        searchInputField.onValueChanged.AddListener(OnSearchFieldChanged);

        nextButton.onClick.AddListener(ShowNextModel);
        previousButton.onClick.AddListener(ShowPreviousModel);
        exploreButton.onClick.AddListener(showExplore);


        if (renderableModels.Count > 0)
        {
            ShowModelByIndex(currentModelIndex);
        }
        else
        {
            Debug.LogError("Keine renderbaren Modelle gefunden!");
        }
    }


    void OnSearchFieldChanged(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
        {
            scrollView.SetActive(false);
            ShowModelByIndex(currentModelIndex);
        }
        else
        {
            scrollView.SetActive(true);
            Search(searchText);
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
        Debug.Log($"Ausgew�hlt: {result.german_name} ({result.latin_name})");

        string displayText = result.german_name.Length > 30
        ? result.german_name.Substring(0, 27) + "..."
        : result.german_name;
        searchInputField.text = displayText;

        for (int i = 0; i < renderableModels.Count; i++)
        {
            if (renderableModels[i].gameObject.name.Contains(result.latin_name, System.StringComparison.OrdinalIgnoreCase))
            {
                currentModelIndex = i;
                ShowModelByIndex(currentModelIndex);
                break;
            }
        }

        scrollView.SetActive(false);
    }

    void ShowNextModel()
    {
        if (renderableModels.Count == 0 || currentModelIndex >= renderableModels.Count - 1) return;

        currentModelIndex++;
        ShowModelByIndex(currentModelIndex);
        searchInputField.text = "";
    }

    void ShowPreviousModel()
    {
        if (renderableModels.Count == 0 || currentModelIndex <= 0) return;

        currentModelIndex--;
        ShowModelByIndex(currentModelIndex);
        searchInputField.text = "";
    }


    void UpdateButtonStates()
    {
        previousButton.interactable = currentModelIndex > 0;
        var previousButtonImage = previousButton.GetComponent<Image>();
        if (previousButtonImage != null)
        {
            if (previousButton.interactable)
            {
                previousButtonImage.color = Color.white;
            }
            else
            {
                previousButtonImage.color = Color.gray;
                leftText.text = "";
            }
        }

        nextButton.interactable = currentModelIndex < renderableModels.Count - 1;
        var nextButtonImage = nextButton.GetComponent<Image>();
        if (nextButtonImage != null)
        {
            if (nextButton.interactable)
            {
                nextButtonImage.color = Color.white;
            }
            else
            {
                nextButtonImage.color = Color.gray;
                rightText.text = "";
            }
        }
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

    List<Renderer> GetRenderableModels()
    {
        List<Renderer> renderableModels = new List<Renderer>();

        if (fbxRoot == null)
        {
            Debug.LogError("FBX Root Object ist nicht zugewiesen!");
            return renderableModels;
        }

        //  fbxRoot.transform.localPosition = Vector3.zero;
        //  fbxRoot.transform.localRotation = Quaternion.identity;
        //  fbxRoot.transform.localScale = Vector3.one;

        foreach (Transform child in fbxRoot.GetComponentsInChildren<Transform>(true))
        {
            // child.position = Vector3.zero;
            Debug.Log($"Child Name: {child.name}, LocalPosition: {child.localPosition}, LocalRotation: {child.localRotation}, LocalScale: {child.localScale}");

            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderableModels.Add(renderer);
            }
        }

        return renderableModels.OrderBy(r => r.gameObject.name).ToList();
    }

    void UpdateDisplayedText()
    {
        int leftIndex = (currentModelIndex > 0) ? currentModelIndex - 1 : renderableModels.Count - 1;
        int rightIndex = (currentModelIndex < renderableModels.Count - 1) ? currentModelIndex + 1 : 0;

        string centerLatinName = GetLatinNameForModel(renderableModels[currentModelIndex].gameObject.name);
        string leftLatinName = GetLatinNameForModel(renderableModels[leftIndex].gameObject.name);
        string rightLatinName = GetLatinNameForModel(renderableModels[rightIndex].gameObject.name);

        centerText.text = centerLatinName ?? "Unbekannt";
        leftText.text = leftLatinName ?? "Unbekannt";
        rightText.text = rightLatinName ?? "Unbekannt";
    }

    string GetLatinNameForModel(string modelName)
    {
        var anatomicalStructures = ds.GetAnatomicalStructures();
        foreach (var structure in anatomicalStructures)
        {
            if (modelName.Contains(structure.latin_name, System.StringComparison.OrdinalIgnoreCase))
            {
                return structure.latin_name;
            }
        }
        return null;
    }
    void setDescription(int id)
    {

        var descriptions = ds.GetDescription(id);
        foreach (var description in descriptions)
        {
            descriptionText.text = description.text;
        }

    }

    void ShowModelByIndex(int index)
    {
        if (index < 0 || index >= renderableModels.Count)
        {
            Debug.LogError("Ungültiger Modellindex!");
            return;
        }

        Renderer targetRenderer = renderableModels[index];

        Vector3 targetLocalPosition = targetRenderer.transform.localPosition;

        targetLocalPosition.y += 0.35f;

        fbxRoot.transform.localPosition = -targetLocalPosition;


        // Setze die Transparenz für alle Modelle
        for (int i = 0; i < renderableModels.Count; i++)
        {
            if (i == index)
            {
                SetMaterialTransparency(renderableModels[i], 1.0f);
            }
            else
            {
                SetMaterialTransparency(renderableModels[i], 0.0f);
            }
        }

        // Aktualisiere die Texte, Beschreibung und Buttons
        string latinName = GetLatinNameForModel(renderableModels[index].gameObject.name);
        int modelId = GetAnatomicalStructureIdByLatinName(latinName);
        UpdateDisplayedText();
        setDescription(modelId);
        UpdateButtonStates();

        Debug.Log($"Angezeigtes Modell: {renderableModels[index].gameObject.name}");
    }

    int GetAnatomicalStructureIdByLatinName(string latinName)
    {
        var anatomicalStructures = ds.GetAnatomicalStructures();
        foreach (var structure in anatomicalStructures)
        {
            if (structure.latin_name.Equals(latinName, System.StringComparison.OrdinalIgnoreCase))
            {
                return structure.id;
            }
        }
        return -1;
    }
    void showExplore()
    {
        ExploreWindow.SetActive(true);
    }
    //vllt jetzt
}
