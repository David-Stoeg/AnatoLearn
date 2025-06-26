using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

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
    
    private string currentHighlightedLatinName = null;
    private bool userHasSearched = false;

    void Start()
    {
        ds = DataServiceManager.Instance.DataService;

        if (!string.IsNullOrEmpty(SceneData.SelectedBodyPartName))
        {
            ApplyTransparencyToFBX(SceneData.SelectedBodyPartName);
        }

        searchInputField.onValueChanged.AddListener(OnSearchFieldChanged);
        skeletonButton.onClick.AddListener(OnButtonSkeletonClick);
        muscleButton.onClick.AddListener(OnButtonMuscleClick);

        scrollView.SetActive(false);

        var anatomicalStructures = ds.GetAnatomicalStructures();
        List<Renderer> renderableModels = GetRenderableModels();

        foreach (var render in renderableModels)
        {
            //Deactivated because of annoying debug spam
            //Debug.Log($"Renderer Found: {render.gameObject.name} → Normalized: {NormalizeName(render.gameObject.name)}");

            bool needsNormalsFix = ValidateMesh(render);
            if (needsNormalsFix)
            {
                RecalculateNormals(render);
            }
        }

        foreach (var result in anatomicalStructures)
        {
            bool modelFound = false;
            string targetName = NormalizeName(result.latin_name);

            foreach (var renderer in renderableModels)
            {
                string rendererName = NormalizeName(renderer.gameObject.name);

                if (rendererName.Contains(targetName))
                {
                    modelFound = true;
                    break;
                }
            }

            if (!modelFound)
            {
                Debug.LogWarning($"❌ Modell nicht gefunden: {result.latin_name} → Normalized: {targetName}");
            }
        }
    }

    void RecalculateNormals(Renderer renderer)
    {
        var meshFilter = renderer.GetComponent<MeshFilter>();
        if (meshFilter == null || meshFilter.sharedMesh == null)
            return;

        Mesh mesh = meshFilter.sharedMesh;
        mesh.RecalculateNormals();

        Debug.Log($"✅ Recalculated normals for: {renderer.gameObject.name}");
    }

    string NormalizeName(string name)
    {
        return new string(name
            .ToLower()
            .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
            .ToArray())
            .Replace(" ", "");
    }

    bool ValidateMesh(Renderer renderer)
    {
        var meshFilter = renderer.GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogWarning($"⚠️ No MeshFilter found on: {renderer.gameObject.name}");
            return false;
        }

        var mesh = meshFilter.sharedMesh;
        if (mesh == null)
        {
            Debug.LogWarning($"⚠️ No Mesh assigned on: {renderer.gameObject.name}");
            return false;
        }

        if (mesh.vertexCount == 0)
        {
            Debug.LogWarning($"❗ Mesh has no vertices: {renderer.gameObject.name}");
        }

        var normals = mesh.normals;
        if (normals == null || normals.Length == 0)
        {
            Debug.LogWarning($"❗ Mesh has no normals: {renderer.gameObject.name}");
            return true;
        }
        else if (normals.All(n => n == Vector3.zero))
        {
            Debug.LogWarning($"❗ All normals are zero vectors in mesh: {renderer.gameObject.name}");
            return true;
        }

        return false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Renderer clickedRenderer = hit.transform.GetComponent<Renderer>();

                if (clickedRenderer != null && IsRendererFullyVisible(clickedRenderer))
                {
                    Debug.Log($"Geklickt: {clickedRenderer.gameObject.name}");
                    switchToHumanExplore(clickedRenderer);
                }
            }
        }
    }

    void switchToHumanExplore(Renderer renderer)
    {
        if (renderer.gameObject.name == "Plane")
        {
            Debug.Log("Debug");
        }
        else
        {
            Debug.Log($"Klick-Event ausgel�st f�r: {renderer.gameObject.name}");

            string targetSceneName = "HumanExplorer";
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                Debug.Log($"Wechsel zu Szene: {targetSceneName}");
                SceneData.RendererName = renderer.gameObject.name;
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Debug.LogWarning("Szenenname f�r den Wechsel ist leer. Bitte Szene zuweisen!");
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

                // Reset search state
                currentHighlightedLatinName = null;
                userHasSearched = false;
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
        Debug.Log($"Ausgew�hlt: {result.german_name} ({result.latin_name})");
        string displayText = result.german_name.Length > 30
            ? result.german_name.Substring(0, 27) + "..."
            : result.german_name;

        searchInputField.text = displayText;
        scrollView.SetActive(false);

        ApplyTransparencyToFBX(result.latin_name);
    }

    void ApplyTransparencyToFBX(string targetModelName)
    {
        currentHighlightedLatinName = targetModelName;
        userHasSearched = true;

        
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
        UpdateCollidersBasedOnTransparency();

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

            if (alpha < 1.0f)
            {
                // Transparent mode
                mat.SetFloat("_Mode", 2);
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                mat.SetInt("_ZWrite", 0);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.EnableKeyword("_ALPHABLEND_ON");
                mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = 3000;
            }
            else
            {
                // Opaque mode
                mat.SetFloat("_Mode", 0);
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                mat.SetInt("_ZWrite", 1);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.DisableKeyword("_ALPHABLEND_ON");
                mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = -1;
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
    
    void OnButtonSkeletonClick()
    {
        List<Renderer> renderableModels = GetRenderableModels();

        foreach (var renderer in renderableModels)
        {
            if (renderer.gameObject.name.Contains("Skeleton_m_V7", System.StringComparison.OrdinalIgnoreCase))
            {
                if (skeletonOn)
                {
                    SetMaterialTransparency(renderer, 0.0f);
                }
                else
                {
                    if (userHasSearched &&
                        !string.IsNullOrEmpty(currentHighlightedLatinName))
                    {
                        SetMaterialTransparency(renderer, 0.1f); // bones stay transparent
                    }
                    else
                    {
                        SetMaterialTransparency(renderer, 1.0f);
                    }
                }
            }
        }

        skeletonOn = !skeletonOn;
        Debug.Log($"Skeleton sichtbar: {skeletonOn}");
    }

    void OnButtonMuscleClick()
    {
        List<Renderer> renderableModels = GetRenderableModels();
        bool anyMuscleModelFound = false;

        string[] muscleKeywords = new string[] { "muscul", "extensor", "flexor", "abductor", "diaphragma", "platysma", "linea alba", "levator labii superioris" };

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
                    // Hide all muscle models
                    SetMaterialTransparency(renderer, 0.0f);
                }
                else
                {
                    // Determine transparency level based on search state
                    if (userHasSearched && !string.IsNullOrEmpty(currentHighlightedLatinName))
                    {
                        if (renderer.gameObject.name.Contains(currentHighlightedLatinName, System.StringComparison.OrdinalIgnoreCase))
                        {
                            SetMaterialTransparency(renderer, 1.0f); // highlighted muscle
                        }
                        else
                        {
                            SetMaterialTransparency(renderer, 0.1f); // dim others
                        }
                    }
                    else
                    {
                        SetMaterialTransparency(renderer, 1.0f); // no search = fully visible
                    }
                }
            }
            else
            {
                Debug.LogWarning($"❗ Not identified as muscle: {renderer.gameObject.name}");
            }
        }

        if (anyMuscleModelFound)
        {
            muscleOn = !muscleOn;
        }

        Debug.Log($"Muskel-Transparenzmodus: {muscleOn}");
    }

    void UpdateCollidersBasedOnTransparency()
    {
        List<Renderer> renderableModels = GetRenderableModels();

        foreach (var renderer in renderableModels)
        {
            bool isFullyVisible = IsRendererFullyVisible(renderer);

            if (renderer.transform.IsChildOf(fbxRoot.transform))
            {
                Collider collider = renderer.gameObject.GetComponent<Collider>();
                if (collider == null)
                {
                    collider = renderer.gameObject.AddComponent<BoxCollider>();
                }
                collider.enabled = isFullyVisible;
            }
        }
    }

    bool IsRendererFullyVisible(Renderer renderer)
    {
        foreach (Material mat in renderer.materials)
        {
            if (mat.color.a < 1.0f) 
            {
                return false;
            }
        }
        return true;
    }
}
