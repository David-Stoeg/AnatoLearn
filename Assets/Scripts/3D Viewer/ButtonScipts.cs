using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScipts : MonoBehaviour
{
    [Tooltip("Place object named 'ConstantPanel' here. \nBaseForRotation > Main Camera > Canvas > ConstantPanel")]
    public GameObject ConstantTextPanel;

    [Tooltip("Place object named 'UserControlPanel' here. \nBaseForRotation > Main Camera > Canvas > UserControlPanel")]
    public GameObject UserControlPanel;

    [Tooltip("Place object named 'DisableTextButton' here. \nBaseForRotation > Main Camera > Canvas > DisableTextButton")]
    public Button DisableTextButton;

    [Tooltip("Place object named 'AutoButton' here. \nBaseForRotation > Main Camera > Canvas > ConstantPanel > AutoButton")]
    public Button AutoModeButton;

    [Tooltip("Value between 0 and 1.\nDetermines how transparent the DisableTextButton is when text is disabled.")]
    public float disabledAlphaValue = .5f;

    [Tooltip("Place object named 'PlayAnimationButton' here. \nUI Button that triggers the animation.")]
    public Button PlayAnimationButton; // Button for animation toggle

    private Animator animator; // Animator for controlling the animation
    private bool isTextEnabled = true;
    private bool isOnAuto = false; // Replaces UserInput.isOnAuto

    // Add SetCurrentModel method here
    public void SetCurrentModel(GameObject model)
    {
        Debug.Log("Current model set: " + model.name);  // Log the current model to the console
    }

    private void OnEnable()
    {
        if (AutoModeButton != null)
        {
            AutoModeButton.onClick.AddListener(AutoModeButtonCall);
        }

        if (DisableTextButton != null)
        {
            DisableTextButton.onClick.AddListener(DisableTextButtonCall);
        }

        if (PlayAnimationButton != null)
        {
            PlayAnimationButton.onClick.AddListener(OnPlayAnimationButtonClick);
        }
    }

    private void OnDisable()
    {
        if (AutoModeButton != null)
        {
            AutoModeButton.onClick.RemoveListener(AutoModeButtonCall);
        }

        if (DisableTextButton != null)
        {
            DisableTextButton.onClick.RemoveListener(DisableTextButtonCall);
        }

        if (PlayAnimationButton != null)
        {
            PlayAnimationButton.onClick.RemoveListener(OnPlayAnimationButtonClick);
        }
    }

    private void OnPlayAnimationButtonClick()
    {
        if (animator != null)
        {
            bool isAnimationPlaying = animator.GetCurrentAnimatorStateInfo(0).IsName("TestAni");

            if (isAnimationPlaying)
            {
                animator.SetTrigger("TestAniStill");
            }
            else
            {
                animator.SetTrigger("TestAni");
            }
        }
    }

    public void DisableTextButtonCall()
    {
        Color textButtonColor = DisableTextButton.image.color;
        Text buttonText = DisableTextButton.GetComponentInChildren<Text>();
        if (isTextEnabled)
        {
            isTextEnabled = false;
            ConstantTextPanel.SetActive(false);
            if (!isOnAuto)
            {
                UserControlPanel.SetActive(false);
            }
            textButtonColor.a = disabledAlphaValue;
            DisableTextButton.image.color = textButtonColor;
            buttonText.text = "Enable Text";
        }
        else
        {
            isTextEnabled = true;
            ConstantTextPanel.SetActive(true);
            if (!isOnAuto)
            {
                UserControlPanel.SetActive(true);
            }
            textButtonColor.a = 1;
            DisableTextButton.image.color = textButtonColor;
            buttonText.text = "Disable Text";
        }
    }

    private void AutoModeButtonCall()
    {
        isOnAuto = !isOnAuto; // Toggle auto mode
        Text buttonText = AutoModeButton.GetComponentInChildren<Text>();
        if (!isOnAuto)
        {
            UserControlPanel.SetActive(true);
            buttonText.text = "Auto Mode: OFF";
        }
        else
        {
            UserControlPanel.SetActive(false);
            buttonText.text = "Auto Mode: ON";
        }
    }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
}
