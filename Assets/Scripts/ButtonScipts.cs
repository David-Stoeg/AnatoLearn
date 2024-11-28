using System.Collections;
using System.Collections.Generic;
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

    // Add SetCurrentModel method here
    public void SetCurrentModel(GameObject model)
    {
        // You can use this method to do whatever you need with the model
        Debug.Log("Current model set: " + model.name);  // Example of logging the model name to the console
    }

    private void OnEnable()
    {
        UserInput.AutoRotateClicked += AutoModeButtonCall;
        
        // Add button click listener for PlayAnimationButton
        if (PlayAnimationButton != null)
        {
            PlayAnimationButton.onClick.AddListener(OnPlayAnimationButtonClick);
        }
    }

    private void OnDisable()
    {
        UserInput.AutoRotateClicked -= AutoModeButtonCall;
        
        // Remove button click listener
        if (PlayAnimationButton != null)
        {
            PlayAnimationButton.onClick.RemoveListener(OnPlayAnimationButtonClick);
        }
    }

    // Method to trigger animation play/pause when PlayAnimationButton is clicked
    private void OnPlayAnimationButtonClick()
    {
        if (animator != null)
        {
            // Toggle between animations
            bool isAnimationPlaying = animator.GetCurrentAnimatorStateInfo(0).IsName("TestAni");

            if (isAnimationPlaying)
            {
                // Switch to idle animation
                animator.SetTrigger("TestAniStill");
            }
            else
            {
                // Switch to active animation
                animator.SetTrigger("TestAni");
            }
        }
    }

    // Method to handle Disable Text Button logic
    public void DisableTextButtonCall()
    {
        Color textButtonColor = DisableTextButton.image.color;
        Text buttonText = DisableTextButton.GetComponentInChildren<Text>();
        if(isTextEnabled)
        {
            isTextEnabled = false;
            ConstantTextPanel.SetActive(false);
            if(!UserInput.isOnAuto)
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
            if (!UserInput.isOnAuto)
            {
                UserControlPanel.SetActive(true);
            }
            textButtonColor.a = 1;
            DisableTextButton.image.color = textButtonColor;
            buttonText.text = "Disable Text";
        }
    }

    // Method for Auto Mode button behavior
    private void AutoModeButtonCall()
    {
        Text buttonText = AutoModeButton.GetComponentInChildren<Text>();
        if(!UserInput.isOnAuto)
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

    // Start method where Animator is assigned
    void Start()
    {
        // Get the Animator component from the GameObject or child GameObject
        animator = GetComponentInChildren<Animator>();
    }
}
