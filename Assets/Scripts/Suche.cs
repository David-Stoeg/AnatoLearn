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
    public GameObject fbxRoot;
    public Button skeletonButton;
    public Button muscleButton;
    public bool skeletonOn = true;
    public bool muscleOn = true;

    private DataService ds;
    private string previousSearchText = "";

    void Start()
    {
        ds = DataServiceManager.Instance.DataService;

        searchInputField.onValueChanged.AddListener(OnSearchFieldChanged);
        skeletonButton.onClick.AddListener(OnButtonSkeletonClick);
        muscleButton.onClick.AddListener(OnButtonMuscleClick);

        scrollView.SetActive(false);

        var anatomicalStructures = ds.GetAnatomicalStructures();
        List<Renderer> renderableModels = GetRenderableModels();

        foreach (var render in renderableModels)
        {
            Debug.Log(render);
        }

        foreach (var result in anatomicalStructures)
        {
            bool modelFound = false;
            string targetName = result.latin_name.ToLower();

            foreach (var renderer in renderableModels)
            {
                string rendererName = renderer.gameObject.name.ToLower();

                if (rendererName.Contains(targetName))
                {
                    modelFound = true;
                    break;
                }
            }

            if (!modelFound)
            {
                Debug.LogWarning($"Modell nicht gefunden: {result.latin_name}");
            }
        }
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

    void OnSuggestionClicked(AnatomicalStructures result)
    {
        Debug.Log($"Ausgewählt: {result.german_name} ({result.latin_name})");
        string displayText = result.german_name.Length > 30
            ? result.german_name.Substring(0, 27) + "..."
            : result.german_name;

        searchInputField.text = displayText;
        scrollView.SetActive(false);

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

        List<Renderer> renderableModels = GetRenderableModels();

        foreach (var renderer in renderableModels)
        {
            if (renderer.gameObject.name.Contains(targetModelName, System.StringComparison.OrdinalIgnoreCase))
            {

                SetMaterialTransparency(renderer, 1.0f);
                modelFound = true;
            }
            else
            {
                SetMaterialTransparency(renderer, 0.1f);
            }
        }

        if (!modelFound)
        {
            Debug.LogWarning($"Modell mit lateinischem Namen {targetModelName} wurde nicht gefunden.");
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
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderableModels.Add(renderer);
            }
        }

        return renderableModels;
    }
    void OnButtonSkeletonClick()
    {
        List<Renderer> renderableModels = GetRenderableModels();
        foreach (var renderer in renderableModels)
        {
            if (renderer.gameObject.name.Contains("Skeleton_m_V7", System.StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log($"Modell gefunden: {renderer.gameObject.name}");

                if (skeletonOn == true)
                {
                    SetMaterialTransparency(renderer, 0.0f);
                    skeletonOn = false;
                }
                else
                {
                    SetMaterialTransparency(renderer, 1.0f);
                    skeletonOn = true;
                }
                Debug.Log(skeletonOn);
            }
        }
    }
    void OnButtonMuscleClick()
    {
        List<Renderer> renderableModels = GetRenderableModels();

        bool anyMuscleModelFound = false;

        string[] muscleKeywords = new string[] { "muscul", "extensor", "flexor", "abductor", "diaphragma" };

        foreach (var renderer in renderableModels)
        {
            bool isMuscleModel = false;

            foreach (string keyword in muscleKeywords)
            {
                if (renderer.gameObject.name.Contains(keyword, System.StringComparison.OrdinalIgnoreCase))
                {
                    isMuscleModel = true;
                    break;
                }
            }

            if (isMuscleModel)
            {
                anyMuscleModelFound = true;

                if (muscleOn)
                {
                    SetMaterialTransparency(renderer, 0.0f);
                }
                else
                {
                    SetMaterialTransparency(renderer, 1.0f);
                }
            }
        }

        if (anyMuscleModelFound)
        {
            muscleOn = !muscleOn;
        }
        else
        {
            Debug.LogWarning("Keine passenden Muskelmodelle gefunden.");
        }

        Debug.Log($"Muskel-Transparenzmodus: {muscleOn}");
    }


}
