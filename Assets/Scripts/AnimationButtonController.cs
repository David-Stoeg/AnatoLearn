using UnityEngine;
using UnityEngine.UI;

public class AnimationButtonController : MonoBehaviour
{
    [Tooltip("The Animator component controlling the animations.")]
    public Animator animator;

    [Tooltip("The button that triggers the animation.")]
    public Button animationButton;

    // State to track whether the animation is playing
    private bool isPlayingAnimation = false;

    private void Start()
    {
        // Ensure the button and animator are assigned
        if (animationButton == null)
        {
            Debug.LogError("AnimationButton is not assigned.");
            return;
        }

        if (animator == null)
        {
            Debug.LogError("Animator is not assigned.");
            return;
        }

        // Set the idle animation to play by default
        animator.Play("TestAniStill");

        // Add the listener to the button click event
        animationButton.onClick.AddListener(ToggleAnimation);
    }

    private void ToggleAnimation()
    {
        if (isPlayingAnimation)
        {
            // Play the idle animation
            animator.Play("TestAniStill");
        }
        else
        {
            // Play the main animation
            animator.Play("TestAni");
        }

        // Toggle the state
        isPlayingAnimation = !isPlayingAnimation;
    }

    private void OnDestroy()
    {
        // Remove the listener when the script is destroyed
        if (animationButton != null)
        {
            animationButton.onClick.RemoveListener(ToggleAnimation);
        }
    }
}