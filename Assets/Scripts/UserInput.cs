using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ModelInspector : MonoBehaviour
{
    public Transform children; // Das Objekt zum Rotieren
    public Camera camera; // Die Hauptkamera
    public float speed = 10f; // Rotations- und Bewegungs-Geschwindigkeit
    public float scrollSpeed = 2f; // Zoom-Geschwindigkeit
    public float climbSpeed = 5f; // Vertikale Bewegungsgeschwindigkeit
    private float zoomAmount = 0f; // Aktuelles Zoom-Level
    private bool isInteractingWithUI = false; // UI-Interaktion verhindern

    // UI-Referenzen
    public Button animationButton;
    public Button infoButton;
    public Button searchButton;
    public CanvasGroup animationSliderCanvasGroup; // Der AnimationSlider
    public GameObject floatingMenu; // Das Menü mit den Buttons

    // Standardwerte für Position, Rotation und Zoom speichern
    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    private float defaultZoomAmount;

    private void Start()
    {
        // Standardwerte speichern
        defaultPosition = camera.transform.position;
        defaultRotation = children.rotation;
        defaultZoomAmount = zoomAmount;

        // AnimationSlider am Anfang ausblenden
        ShowAnimationSlider(false);

        // Button-Events hinzufügen
        animationButton.onClick.AddListener(ToggleAnimationSlider);
        infoButton.onClick.AddListener(HideAnimationSlider);
        searchButton.onClick.AddListener(HideAnimationSlider);
    }

    private void ToggleAnimationSlider()
    {
        bool isCurrentlyVisible = animationSliderCanvasGroup.alpha > 0;
        ShowAnimationSlider(!isCurrentlyVisible);
    }

    private void ShowAnimationSlider(bool show)
    {
        animationSliderCanvasGroup.alpha = show ? 1 : 0;
        animationSliderCanvasGroup.interactable = show;
        animationSliderCanvasGroup.blocksRaycasts = show;

        // FloatingMenu ausblenden, wenn der AnimationSlider sichtbar ist
        floatingMenu.SetActive(!show);
    }

    private void HideAnimationSlider()
    {
        ShowAnimationSlider(false);
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            HandleTouchInput();
        }
        else
        {
            HandlePCInput();
        }

        // Zurücksetzen mit "R"-Taste
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetToDefault();
        }
    }

    private void HandlePCInput()
    {
        if (Input.GetMouseButtonDown(0)) isInteractingWithUI = EventSystem.current.IsPointerOverGameObject();
        if (isInteractingWithUI && Input.GetMouseButtonUp(0)) isInteractingWithUI = false;
        if (isInteractingWithUI) return;

        // Rotation (Linke Maustaste)
        if (Input.GetMouseButton(0))
        {
            float rotX = -Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            float rotY = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;

            children.Rotate(Vector3.up * rotX, Space.World);
            if (ModelOrganizer.models[ModelOrganizer.listPtr].GetComponent<ModelInfo>().shouldSeeUnderside)
                children.Rotate(Vector3.right * rotY, Space.World);
        }

        // Bewegung (Rechte Maustaste) - Skaliert mit Zoom
        if (Input.GetMouseButton(1))
        {
            float zoomFactor = Mathf.Lerp(1f, 0.1f, Mathf.InverseLerp(-10f, 1f, zoomAmount));
            float moveX = Input.GetAxis("Mouse X") * Time.deltaTime * speed * 0.1f * zoomFactor;
            float moveY = Input.GetAxis("Mouse Y") * Time.deltaTime * speed * 0.1f * zoomFactor;

            camera.transform.Translate(-moveX, -moveY, 0, Space.Self);
        }

        // Zoom (Mausrad)
        zoomAmount += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        camera.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, Space.Self);

        // Bewegungstasten
        if (Input.GetKeyDown(KeyCode.W)) ResetZoom();
        if (Input.GetKeyDown(KeyCode.S)) children.rotation = Quaternion.identity;

        if (Input.GetKey(KeyCode.Q)) camera.transform.position += camera.transform.up * climbSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) camera.transform.position -= camera.transform.up * climbSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    private void HandleTouchInput()
    {
        Debug.Log("Touch count: " + Input.touchCount);

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotX = -touch.deltaPosition.x * speed * Time.deltaTime;
                float rotY = touch.deltaPosition.y * speed * Time.deltaTime;

                children.Rotate(Vector3.up * rotX, Space.World);
                if (ModelOrganizer.models[ModelOrganizer.listPtr].GetComponent<ModelInfo>().shouldSeeUnderside)
                    children.Rotate(Vector3.right * rotY, Space.World);

                Debug.Log("Touch Moved: " + touch.deltaPosition);
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            zoomAmount += deltaMagnitudeDiff * 0.01f;
            zoomAmount = Mathf.Clamp(zoomAmount, -10f, 1f);

            camera.transform.Translate(0, 0, -deltaMagnitudeDiff * scrollSpeed * 0.1f, Space.Self);

            Vector2 averageDelta = (touch0.deltaPosition + touch1.deltaPosition) * 0.5f;
            camera.transform.Translate(-averageDelta.x * 0.01f, -averageDelta.y * 0.01f, 0, Space.Self);

            Debug.Log("Pinch Zoom: " + deltaMagnitudeDiff);
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 2) ResetZoom();
    }

    private void ResetZoom()
    {
        zoomAmount = 0f;
        camera.transform.localPosition = Vector3.zero;
    }

    private void ResetToDefault()
    {
        camera.transform.position = defaultPosition;
        children.rotation = defaultRotation;
        zoomAmount = defaultZoomAmount;
        camera.transform.localPosition = Vector3.zero;
    }
}
