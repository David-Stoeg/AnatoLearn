using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

public class HumanExplore : MonoBehaviour
{
    public TMP_InputField searchInputField;
    public GameObject suggestionPrefab;
    public Transform suggestionsParent;
    public GameObject scrollView;
    public GameObject fbxRoot;
    public GameObject ExploreWindow;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public Button nextButton;
    public Button previousButton;
    public Button exploreButton;
    public Button nextDescriptionButton;
    public Button previousDescriptionButton;

    private DataService ds;
    private List<Renderer> renderableModels;
    private int currentModelIndex = 0;
    Vector3 originalPosition;
    int counter = 0;

    public TMP_Text centerText;
    public TMP_Text descriptionText;
    public TMP_Text descriptionText2;
    public TMP_Text descriptionText3;

    [SerializeField] private RectTransform bottomSheet;


    void Start()
    {
        ds = DataServiceManager.Instance.DataService;
        renderableModels = GetRenderableModels();
        originalPosition = new Vector3(0.00f, 0.05f, 3.00f);

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
        nextDescriptionButton.onClick.AddListener(ShowNextDescription);
        previousDescriptionButton.onClick.AddListener(ShowPreviousDescription);

        if (renderableModels.Count > 0)
        {
            ShowModelByIndex(currentModelIndex);
        }
        else
        {
            Debug.LogError("Keine renderbaren Modelle gefunden!");
        }
    }

    void Update()
    {

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
            }
        }

        nextButton.interactable = currentModelIndex < renderableModels.Count - 4;
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

        foreach (Transform child in fbxRoot.GetComponentsInChildren<Transform>(true))
        {
            if (!child.gameObject.name.Contains("WGT"))
            {

                Renderer renderer = child.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderableModels.Add(renderer);
                }
            }
        }

        return renderableModels.ToList();
    }

    void UpdateDisplayedText()
    {
        int leftIndex = (currentModelIndex > 0) ? currentModelIndex - 1 : renderableModels.Count - 1;
        int rightIndex = (currentModelIndex < renderableModels.Count - 1) ? currentModelIndex + 1 : 0;

        string centerLatinName = GetLatinNameForModel(renderableModels[currentModelIndex].gameObject.name);

        centerText.text = centerLatinName ?? "Unbekannt";
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

        var descriptions = ds.GetDescription(id - 1);
        foreach (var description in descriptions)
        {
            descriptionText.text = description.ansatz;                    
            descriptionText2.text = description.innervation;
            descriptionText3.text = description.funktion;
        }

    }

    void ShowModelByIndex(int index)
    {
        if (renderableModels[index].gameObject.name.Contains("Skeleton"))
        {
            index++;
        }
        if (renderableModels == null)
        {
            Debug.LogError("Fehler: renderableModels ist null!");
            return;
        }

        if (renderableModels.Count == 0)
        {
            Debug.LogError("Fehler: renderableModels enthält keine Modelle!");
            return;
        }

        if (index < 0 || index >= renderableModels.Count)
        {
            Debug.LogError($"Ungültiger Modellindex! index: {index}, erlaubter Bereich: 0 - {renderableModels.Count - 1}");
            return;
        }

        if (fbxRoot == null)
        {
            Debug.LogError("Fehler: fbxRoot ist null!");
            return;
        }

        fbxRoot.transform.position = originalPosition;

        if (renderableModels[index] == null)
        {
            Debug.LogError("Fehler: Das ausgewählte Modell ist null!");
            return;
        }

        string modelName = renderableModels[index].gameObject.name;


        string latinName = GetLatinNameForModel(modelName);

        if (string.IsNullOrEmpty(latinName))
        {
            Debug.LogError("Fehler: Lateinischer Name ist null oder leer!");
            Debug.Log(modelName);
            counter++;
            Debug.Log(counter);
            return;

        }

        Renderer targetRenderer = renderableModels[index];
        if (targetRenderer == null)
        {
            Debug.LogError("Fehler: targetRenderer ist null!");
            return;
        }

        Vector3 targetLocalPosition = targetRenderer.transform.localPosition;

        string CleanName(string name)
        {
            return name.Replace("(sin.)", "").Replace("(dex.)", "").Trim();
        }

        string cleanedName1 = CleanName(latinName);

        double averageX = 0;

        Vector3 newPosition = Vector3.zero;

        if (latinName.Contains("sin"))
        {
            float modellSize = 0f;
            foreach (var model in renderableModels)
            {
                if (model == null || model.gameObject == null)
                {
                    Debug.LogWarning("Warnung: Ein Modell in renderableModels ist null!");
                    continue;
                }

                string name = GetLatinNameForModel(model.gameObject.name);
                if (string.IsNullOrEmpty(name))
                {
                    Debug.LogWarning($"Warnung: Das Modell {model.gameObject.name} einen leeren lateinischen Namen!");
                    continue;
                }

                if (name.Contains(cleanedName1) && name.Contains("dex"))
                {
                    Vector3 localPositionModel = model.transform.localPosition;
                    averageX = Math.Abs((localPositionModel.x - targetLocalPosition.x) / 2);
                    Bounds bounds = model.bounds;

                    float modelSize= bounds.center.x;
                }
            }
            newPosition = new Vector3(
            fbxRoot.transform.position.x - ((float)averageX + modellSize),
            fbxRoot.transform.position.y - targetLocalPosition.y,
            fbxRoot.transform.position.z - 2f);

            

        }
        else if (latinName.Contains("dex"))
        {
            float modellSize = 0f;
            float minY = float.MaxValue;
            float maxY = float.MinValue;
            foreach (var model in renderableModels)
            {

                if (model == null || model.gameObject == null)
                {
                    Debug.LogWarning("Warnung: Ein Modell in renderableModels ist null!");
                    continue;
                }

                string name = GetLatinNameForModel(model.gameObject.name);
                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }

                if (name.Contains(cleanedName1) && name.Contains("sin"))
                {

                    Vector3 localPositionModel = model.transform.localPosition;

                    averageX = Math.Abs((localPositionModel.x - targetLocalPosition.x) / 2);

                    minY = Mathf.Min(minY, localPositionModel.y);
                    maxY = Mathf.Max(maxY, localPositionModel.y);
                    Bounds bounds = model.bounds;

                    float modelSize = bounds.center.x;
                }
            }
            newPosition = new Vector3(
            fbxRoot.transform.position.x + ((float)averageX - modellSize),
            fbxRoot.transform.position.y - targetLocalPosition.y,
            fbxRoot.transform.position.z - 2f);
            
        }
        else
        {
            float minX = float.MaxValue;
            float maxX = float.MinValue;
            float minY = float.MaxValue;
            float maxY = float.MinValue;
            foreach (var model in renderableModels)
            {
                if (model == null || model.gameObject == null)
                {
                    Debug.LogWarning("Warnung: Ein Modell in renderableModels ist null!");
                    continue;
                }

                if (string.IsNullOrEmpty(name))
                {
                    Debug.LogWarning("Warnung: Ein Modell hat einen leeren lateinischen Namen!");
                    continue;
                }


                Vector3 localPositionModel = model.transform.localPosition;
                minX = Mathf.Min(minX, localPositionModel.x);
                maxX = Mathf.Max(maxX, localPositionModel.x);
                minY = Mathf.Min(minY, localPositionModel.y);
                maxY = Mathf.Max(maxY, localPositionModel.y);


            }
            float middleX = (maxX + minX) / 2;
            float rootX = targetRenderer.transform.localPosition.x - middleX;
            float middleY = (maxY + minY) / 2;
            float rootY = targetRenderer.transform.localPosition.y + middleY;
            newPosition = new Vector3(
            fbxRoot.transform.position.x,
                fbxRoot.transform.position.y - targetLocalPosition.y,
                fbxRoot.transform.position.z -2f);


        }


        fbxRoot.transform.position = newPosition;

        for (int i = 0; i < renderableModels.Count; i++)
        {
            if (renderableModels[i] == null)
            {
                Debug.LogWarning($"Warnung: Modell bei Index {i} ist null!");
                continue;
            }
            SetMaterialTransparency(renderableModels[i], i == index ? 1.0f : 0.05f);
        }

        int modelId = GetAnatomicalStructureIdByLatinName(latinName);

        UpdateDisplayedText();

        setDescription(modelId);

        ExploreWindow.SetActive(false);

        UpdateButtonStates();
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
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
        UpdateDescriptionButtonState(nextDescriptionButton, true);
        UpdateDescriptionButtonState(previousDescriptionButton, false);
        ExploreWindow.SetActive(true);
        bottomSheet.anchoredPosition = new Vector2(0, 350f);
    }
    void ShowNextDescription()
    {
        if (panel1.activeSelf)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
            UpdateDescriptionButtonState(nextDescriptionButton, true);
        }
        else if (panel2.activeSelf)
        {
            panel2.SetActive(false);
            panel3.SetActive(true);
            UpdateDescriptionButtonState(nextDescriptionButton, false);
            UpdateDescriptionButtonState(previousDescriptionButton, true);
        }
    }

    void ShowPreviousDescription()
    {
        if (panel3.activeSelf)
        {
            panel3.SetActive(false);
            panel2.SetActive(true);
            UpdateDescriptionButtonState(previousDescriptionButton, true);
        }
        else if (panel2.activeSelf)
        {
            panel2.SetActive(false);
            panel1.SetActive(true);
            UpdateDescriptionButtonState(previousDescriptionButton, false);
            UpdateDescriptionButtonState(nextDescriptionButton, true);
        }
    }

    void UpdateDescriptionButtonState(Button button, bool isActive)
    {
        var buttonImage = button.GetComponent<Image>();
        button.interactable = isActive;
        if (buttonImage != null)
        {
            buttonImage.color = isActive ? Color.white : Color.gray;
        }
    }

}
