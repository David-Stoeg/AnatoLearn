/*using UnityEngine;
using UnityEngine.UI;

public class PingPongAnimationControl : MonoBehaviour
{
    public Slider slider;              // Reference to the slider
    public Button playPauseButton;     // Reference to the play/pause button
    public Animator animator;          // Reference to the Animator
    public string animationName;       // Name of the animation clip

    private AnimationClip clip;
    private float animationLength;
    private float currentTime = 0f;    // Tracks the current animation time
    private bool isPlaying = false;
    private bool isForward = true;     // Playback direction

    void Start()
    {
        // Get the animation clip from the Animator
        if (animator != null)
        {
            foreach (var animClip in animator.runtimeAnimatorController.animationClips)
            {
                if (animClip.name == animationName)
                {
                    clip = animClip;
                    animationLength = clip.length;
                    break;
                }
            }
        }

        if (slider != null && clip != null)
        {
            slider.maxValue = animationLength;
            slider.onValueChanged.AddListener(SliderChanged);
        }

        if (playPauseButton != null)
        {
            playPauseButton.onClick.AddListener(TogglePlayPause);
        }
    }

    void Update()
    {
        if (isPlaying && clip != null)
        {
            // Update current time based on playback direction
            currentTime += (isForward ? 1 : -1) * Time.deltaTime;

            // Offset to avoid glitches at boundaries
            const float epsilon = 0.001f;

            // Check for direction changes at boundaries
            if (currentTime >= animationLength - epsilon)
            {
                currentTime = animationLength - epsilon; // Stay just before the last frame
                isForward = false;
            }
            else if (currentTime <= epsilon)
            {
                currentTime = epsilon; // Stay just after the first frame
                isForward = true;
            }

            // Update the slider and animation
            slider.value = currentTime;
            animator.Play(animationName, 0, currentTime / animationLength);
        }
    }

    void SliderChanged(float value)
    {
        if (!isPlaying) // Only update animation if not playing
        {
            currentTime = value;
            animator.Play(animationName, 0, currentTime / animationLength);
            animator.speed = 0; // Ensure animation is paused
        }
    }

    void TogglePlayPause()
    {
        if (isPlaying)
        {
            animator.speed = 0; // Pause
            isPlaying = false;
        }
        else
        {
            animator.speed = 1; // Resume
            isPlaying = true;
        }
    }
}*/

using UnityEngine;
using UnityEngine.UI;

public class PingPongAnimationControl : MonoBehaviour
{
    public Slider slider;              // Reference to the slider
    public Button playPauseButton;     // Reference to the play/pause button
    public Image playPauseImage;       // Reference to the image component of the button
    public Sprite playSprite;          // Sprite for the play icon
    public Sprite pauseSprite;         // Sprite for the pause icon
    public Animator animator;          // Reference to the Animator
    public string animationName;       // Name of the animation clip

    private AnimationClip clip;
    private float animationLength;
    private float currentTime = 0f;    // Tracks the current animation time
    private bool isPlaying = false;
    private bool isForward = true;     // Playback direction

    void Start()
    {
        // Get the animation clip from the Animator
        if (animator != null)
        {
            foreach (var animClip in animator.runtimeAnimatorController.animationClips)
            {
                if (animClip.name == animationName)
                {
                    clip = animClip;
                    animationLength = clip.length;
                    break;
                }
            }
        }

        if (slider != null && clip != null)
        {
            slider.maxValue = animationLength;
            slider.onValueChanged.AddListener(SliderChanged);
        }

        if (playPauseButton != null)
        {
            playPauseButton.onClick.AddListener(TogglePlayPause);
        }

        UpdatePlayPauseIcon(); // Ensure the correct icon is displayed initially
    }

    void Update()
    {
        if (isPlaying && clip != null)
        {
            // Update current time based on playback direction
            currentTime += (isForward ? 1 : -1) * Time.deltaTime;

            // Offset to avoid glitches at boundaries
            const float epsilon = 0.001f;

            // Check for direction changes at boundaries
            if (currentTime >= animationLength - epsilon)
            {
                currentTime = animationLength - epsilon; // Stay just before the last frame
                isForward = false;
            }
            else if (currentTime <= epsilon)
            {
                currentTime = epsilon; // Stay just after the first frame
                isForward = true;
            }

            // Update the slider and animation
            slider.value = currentTime;
            animator.Play(animationName, 0, currentTime / animationLength);
        }
    }

    void SliderChanged(float value)
    {
        if (!isPlaying) // Only update animation if not playing
        {
            currentTime = value;
            animator.Play(animationName, 0, currentTime / animationLength);
            animator.speed = 0; // Ensure animation is paused
        }
    }

    void TogglePlayPause()
    {
        isPlaying = !isPlaying;

        if (isPlaying)
        {
            animator.speed = 1; // Resume
        }
        else
        {
            animator.speed = 0; // Pause
        }

        UpdatePlayPauseIcon();
    }

    void UpdatePlayPauseIcon()
    {
        if (playPauseImage != null)
        {
            playPauseImage.sprite = isPlaying ? pauseSprite : playSprite;
        }
    }
}

