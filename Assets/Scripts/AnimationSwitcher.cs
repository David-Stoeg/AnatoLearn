using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimationSwitcher : MonoBehaviour
{
    public PingPongAnimationControl pingPongScript;
    public TMP_Text centerText;
    public Button nextButton;
    public Button previousButton;

    [SerializeField] private Animator animator; // Exposed in Inspector
    [SerializeField] private AnimationState[] animationStates; // Custom class to hold display and state info

    private int currentIndex = 0;
    private RuntimeAnimatorController runtimeAnimatorController; // Reference to the Animator's runtime controller
    private AnimationClip[] animationClips; // Array to hold animation clips

    // Custom class to hold animation state information
    [System.Serializable]
    public class AnimationState
    {
        public string displayName; // Friendly name to be displayed in the text box
        public string stateName; // The actual name of the Animator state (used internally)
    }

    void Start()
    {
        if (animator == null)
        {
            Debug.LogError("Animator component is not assigned in the Inspector.");
            return;
        }

        // Get the Animator's runtime controller and all animation clips
        runtimeAnimatorController = animator.runtimeAnimatorController;
        animationClips = runtimeAnimatorController.animationClips;

        if (animationClips.Length == 0)
        {
            Debug.LogError("No animation clips found in the Animator.");
            return;
        }

        if (animationStates.Length > 0)
        {
            currentIndex = 0; // Ensure the first animation is selected
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

        // Find the corresponding animation clip based on the Animator state name
        AnimationClip currentClip = GetAnimationClipByStateName(currentState.stateName);

        if (currentClip != null && pingPongScript != null)
        {
            pingPongScript.SetAnimationName(currentClip.name);
        }

        // Display the friendly name in the text box
        if (centerText != null)
        {
            centerText.text = $"Selected Animation: <b>{currentState.displayName}</b>";
        }

        UpdateButtonStates();
    }

    // Utility function to get the animation clip by Animator state name
    AnimationClip GetAnimationClipByStateName(string stateName)
    {
        foreach (var clip in animationClips)
        {
            if (clip.name.Equals(stateName, System.StringComparison.OrdinalIgnoreCase))
            {
                return clip;
            }
        }
        Debug.LogWarning($"Animation clip for state '{stateName}' not found.");
        return null;
    }

    void UpdateButtonStates()
    {
        if (previousButton != null) previousButton.interactable = currentIndex > 0;
        if (nextButton != null) nextButton.interactable = currentIndex < animationStates.Length - 1;
    }
}
