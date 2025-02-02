using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimationSwitcher : MonoBehaviour
{
    public PingPongAnimationControl pingPongScript;
    public TMP_Text centerText;
    public Button nextButton;
    public Button previousButton;

    [SerializeField] private Animator animator;
    [SerializeField] private AnimationState[] animationStates;

    private int currentIndex = 0;
    private RuntimeAnimatorController runtimeAnimatorController;
    private AnimationClip[] animationClips;

    public Button buttonAnimationsliste;
    public GameObject scrollView;
    public GameObject suggestionPrefab;
    public Transform suggestionsParent;

    [System.Serializable]
    public class AnimationState
    {
        public string displayName;
        public string stateName;
    }

    void Start()
    {
        scrollView.SetActive(false);
        buttonAnimationsliste.onClick.AddListener(ShowAnimationList);
        if (animator == null)
        {
            Debug.LogError("Animator component is not assigned in the Inspector.");
            return;
        }

        runtimeAnimatorController = animator.runtimeAnimatorController;
        animationClips = runtimeAnimatorController.animationClips;

        if (animationClips.Length == 0)
        {
            Debug.LogError("No animation clips found in the Animator.");
            return;
        }

        if (animationStates.Length > 0)
        {
            currentIndex = 0;
            UpdateAnimation();
        }

        if (nextButton != null) nextButton.onClick.AddListener(ShowNextAnimation);
        if (previousButton != null) previousButton.onClick.AddListener(ShowPreviousAnimation);
    }

    void ShowNextAnimation()
    {
        if (currentIndex < animationStates.Length - 1)
        {
            currentIndex++;
            UpdateAnimation();
        }
    }

    void ShowPreviousAnimation()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateAnimation();
        }
    }

    void UpdateAnimation()
    {
        if (animationStates.Length == 0) return;

        AnimationState currentState = animationStates[currentIndex];

        if (pingPongScript != null)
        {
            pingPongScript.SetAnimationName(currentState.stateName);
        }

        if (centerText != null)
        {
            centerText.text = $"Ausgewählte Animation: <b>{currentState.displayName}</b>";
        }

        UpdateButtonStates();
    }

    void UpdateButtonStates()
    {
        if (previousButton != null) previousButton.interactable = currentIndex > 0;
        if (nextButton != null) nextButton.interactable = currentIndex < animationStates.Length - 1;
    }

    void ShowAnimationList()
    {
        bool newActive = !scrollView.activeSelf;
        scrollView.SetActive(newActive);

        if (newActive)
        {
            FillAnimationList();
        }
    }

    void FillAnimationList()
    {
        foreach (Transform child in suggestionsParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < animationStates.Length; i++)
        {
            AnimationState state = animationStates[i];
            GameObject suggestion = Instantiate(suggestionPrefab, suggestionsParent);

            TMP_Text suggestionText = suggestion.GetComponentInChildren<TMP_Text>();
            if (suggestionText != null)
            {
                suggestionText.text = state.displayName;
            }

            Button suggestionButton = suggestion.GetComponent<Button>();
            if (suggestionButton != null)
            {
                int index = i;
                suggestionButton.onClick.AddListener(() => OnAnimationSuggestionClicked(index));
            }
        }
    }

    void OnAnimationSuggestionClicked(int index)
    {
        if (index < 0 || index >= animationStates.Length)
            return;

        AnimationState selectedState = animationStates[index];

        if (pingPongScript != null)
        {
            pingPongScript.SetAnimationName(selectedState.stateName);
        }

        if (centerText != null)
        {
            centerText.text = $"Selected Animation: <b>{selectedState.displayName}</b>";
        }

        currentIndex = index;
        scrollView.SetActive(false);
    }
}
