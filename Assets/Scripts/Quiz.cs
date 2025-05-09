using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    public TMP_InputField EingabeInputField;
    public GameObject fbxRoot;
    public Button SubmitButton;
    public Button EndeButton;
    public Button zurückButton;
    public GameObject scrollView;
    public GameObject suggestionPrefab;
    public Transform suggestionsParent;

    private DataService ds;
    private List<Renderer> renderableModels;
    private int currentModelIndex = 0;
    Vector3 originalPosition;
    int counter = 0;

    List<string> latinNamesHistory = new List<string>();
    List<string> eingabeTextsHistory = new List<string>();
    List<string> korrekt_inkorrekt = new List<string>();
    List<string> results = new List<string>();

    void Start()
    {
        ds = DataServiceManager.Instance.DataService;
        renderableModels = GetRenderableModels();
    
        // Shuffle the renderableModels list
        renderableModels = renderableModels.OrderBy(a => Guid.NewGuid()).ToList();

        originalPosition = new Vector3(0.00f, 0.05f, 3.00f);

        SubmitButton.onClick.AddListener(ShowNextModel);

        if (renderableModels.Count > 0)
        {
            ShowModelByIndex(currentModelIndex);
        }
        else
        {
            Debug.LogError("Keine renderbaren Modelle gefunden!");
        }

        EndeButton.onClick.AddListener(Ende);
        zurückButton.onClick.AddListener(SwitchToMainMenu);
    }

    void Update()
    {

    }
    void ShowNextModel()
    {
        if (renderableModels.Count == 0 || currentModelIndex >= renderableModels.Count - 1) return;

        currentModelIndex++;
        ShowModelByIndex(currentModelIndex);
        validateData(currentModelIndex);
        
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

    void ShowModelByIndex(int index)
    {
        if (currentModelIndex > renderableModels.Count-4) {
            Ende();
        }
        if(currentModelIndex == 0)
        {
            EndeButton.gameObject.SetActive(false);
        }
        else
        {
            EndeButton.gameObject.SetActive(true);
        }
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

                    float modelSize = bounds.center.x;
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
                fbxRoot.transform.position.z - 2f);


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

    void validateData(int index)
    {
        string modelName = renderableModels[index-1].gameObject.name;
        string latinName = GetLatinNameForModel(modelName);
        latinNamesHistory.Add(latinName);
        latinName = latinName.Trim();
        Debug.Log(latinName);
        string eingabeText = EingabeInputField.text;
        eingabeTextsHistory.Add(eingabeText);
        eingabeText = eingabeText.Trim();
        Debug.Log(eingabeText);
        if (latinName.Equals(eingabeText, System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Korrekt");
            korrekt_inkorrekt.Add("Korrekt");
        }
        else
        {
            Debug.Log("Inkorrekt");
            korrekt_inkorrekt.Add("Inkorrekt");
        }
        EingabeInputField.text = "";
    }
    void Ende()
    {
        for (int i = 0; i < korrekt_inkorrekt.Count; i++)
        {
            string colorTag = korrekt_inkorrekt[i] == "korrekt" 
                ? "<b><color=#228B22>korrekt</color></b>"
                : "<b><color=#FF0000>inkorrekt</color></b>";

            results.Add($"Lateinischer Begriff: {latinNamesHistory[i]}, Deine Eingabe: '{eingabeTextsHistory[i]}' ist {colorTag}.");
        }

        foreach (var result in results)
        {
            GameObject suggestion = Instantiate(suggestionPrefab, suggestionsParent);

            TMP_Text suggestionText = suggestion.GetComponentInChildren<TMP_Text>();
            if (suggestionText != null)
            {
                suggestionText.text = result;
            }
        }

        for (int i = 0; i < renderableModels.Count; i++)
        {
            if (renderableModels[i] == null)
            {
                Debug.LogWarning($"Warnung: Modell bei Index {i} ist null!");
                continue;
            }
            SetMaterialTransparency(renderableModels[i], 0.2f);
        }

        fbxRoot.transform.position = new Vector3(originalPosition.x, originalPosition.y - 1f, originalPosition.z - 1f);
        scrollView.SetActive(true);
        EndeButton.gameObject.SetActive(false);
        SubmitButton.gameObject.SetActive(false);
        EingabeInputField.gameObject.SetActive(false);
        zurückButton.gameObject.SetActive(true);
    }
    
    void SwitchToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
