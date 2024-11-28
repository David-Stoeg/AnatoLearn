using UnityEngine;
using UnityEngine.UIElements;

public class SlideController_MainMenue : MonoBehaviour
{
    public VisualElement homeButton;
    public VisualElement profileButton;
    public VisualElement settingsButton;
    public VisualElement sliderHandle;


    private float minValue = 0f;
    private float maxValue = 2f;
    private float currentValue = 0f;

    private bool isDragging = false;

    public VisualElement homePanel;
    public VisualElement profilePanel;
    public VisualElement settingsPanel;

    void Start()
    {
        
        var root = GetComponent<UIDocument>().rootVisualElement;
        homeButton = root.Q<VisualElement>("HomeButton");
        profileButton = root.Q<VisualElement>("ProfileButton");
        settingsButton = root.Q<VisualElement>("SettingsButton");
        sliderHandle = root.Q<VisualElement>("SliderHandle");

        
        homePanel = root.Q<VisualElement>("HomePanel");
        profilePanel = root.Q<VisualElement>("ProfilePanel");
        settingsPanel = root.Q<VisualElement>("SettingsPanel");

        
        UpdateSliderHandlePosition();

        sliderHandle.RegisterCallback<PointerDownEvent>(OnPointerDown);
        sliderHandle.RegisterCallback<PointerMoveEvent>(OnPointerMove);
        sliderHandle.RegisterCallback<PointerUpEvent>(OnPointerUp);
    }

    private void OnPointerDown(PointerDownEvent evt)
    {
        isDragging = true;
    }

    private void OnPointerMove(PointerMoveEvent evt)
    {

        if (isDragging)
        {
            float sliderWidth = homeButton.resolvedStyle.width; 
            float newValue = Mathf.Clamp(evt.localPosition.x / sliderWidth, 0f, 1f); 

    
            currentValue = Mathf.Lerp(minValue, maxValue, newValue);
            UpdateSliderHandlePosition();
            UpdateUIBasedOnSliderValue(); 
        }
    }

    private void OnPointerUp(PointerUpEvent evt)
    {

        isDragging = false;
    }

    private void UpdateSliderHandlePosition()
    {
        float sliderWidth = homeButton.resolvedStyle.width; 
        float handlePosition = Mathf.Lerp(0f, sliderWidth, (currentValue - minValue) / (maxValue - minValue));
        sliderHandle.style.left = handlePosition;  
    }

    private void UpdateUIBasedOnSliderValue()
    {
        if (currentValue < 1)
        {
            homePanel.style.display = DisplayStyle.Flex;
            profilePanel.style.display = DisplayStyle.None;
            settingsPanel.style.display = DisplayStyle.None;
        }
        else if (currentValue < 2)
        {
            homePanel.style.display = DisplayStyle.None;
            profilePanel.style.display = DisplayStyle.Flex;
            settingsPanel.style.display = DisplayStyle.None;
        }
        else
        {
            homePanel.style.display = DisplayStyle.None;
            profilePanel.style.display = DisplayStyle.None;
            settingsPanel.style.display = DisplayStyle.Flex;
        }
    }
}

