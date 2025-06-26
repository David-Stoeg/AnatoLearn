using UnityEngine;
using UnityEngine.EventSystems;

public class ModelController : MonoBehaviour
{
    // Rotation Speed
    [SerializeField] private float rotationSpeedPC = 2.0f; // Rotation speed for PC
    [SerializeField] private float rotationSpeedMobile = 4.0f; // Rotation speed for mobile

    // Movement Speed
    [SerializeField] private float movementSpeedPC = 4.0f; // Movement speed for PC
    [SerializeField] private float movementSpeedMobile = 4.0f; // Movement speed for mobile

    // Zoom Speed
    [SerializeField] private float zoomSpeedPC = 0.5f; // Adjusted zoom speed for PC
    [SerializeField] private float zoomSpeedMobile = 0.075f; // Zoom speed for mobile

    public Camera myCamera;
    public Transform children;

    private Vector3 touchStartPos;
    private Vector3 touchPrevPos;
    private float zoomAmount;
    private bool isInteractingWithUI = false; // Prevent interaction if over UI
    private bool touchStartedOverUI = false; // For detecting if the touch started over the UI

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    private void Start()
    {
        if (myCamera == null)
        {
            myCamera = Camera.main;
        }

        defaultPosition = myCamera.transform.position;
        defaultRotation = children.rotation;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            HandleTouchInput();
        }
        else
        {
            HandlePCInput();
        }

        // Reset to default position and rotation when pressing "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetToDefault();
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch started over the UI
            if (touch.phase == TouchPhase.Began)
            {
                touchStartedOverUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
            }

            // If the touch started over UI, prevent interaction with the model
            if (touchStartedOverUI) return;

            if (touch.phase == TouchPhase.Moved)
            {
                // Convert touch position to Vector3 for subtraction with touchPrevPos (Vector3)
                Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 0);
                Vector3 touchDelta = touchPosition - touchPrevPos;

                // Using mobile rotation speed
                float rotX = -touchDelta.x * rotationSpeedMobile * Time.deltaTime;
                float rotY = touchDelta.y * rotationSpeedMobile * Time.deltaTime;
                children.Rotate(Vector3.up * rotX, Space.World);
                if (ModelOrganizer.models[ModelOrganizer.listPtr].GetComponent<ModelInfo>().shouldSeeUnderside)
                    children.Rotate(Vector3.right * rotY, Space.World);
            }

            touchPrevPos = new Vector3(touch.position.x, touch.position.y, 0); // Update touchPrevPos as Vector3
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

            // Using mobile zoom speed
            zoomAmount += deltaMagnitudeDiff * zoomSpeedMobile;
            myCamera.transform.Translate(0, 0, -deltaMagnitudeDiff * zoomSpeedMobile * 0.1f, Space.Self);

            Vector2 averageDelta = (touch0.deltaPosition + touch1.deltaPosition) * 0.5f;
            myCamera.transform.Translate(-averageDelta.x * 0.01f, -averageDelta.y * 0.01f, 0, Space.Self);
        }

        // Double tap to reset zoom
        if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 2)
        {
            ResetToDefault();
        }

        // Move the model with touch dragging (scale by movementSpeedMobile)
        if (Input.touchCount == 1 && touchPrevPos != Vector3.zero)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // Convert touch position to Vector3
                Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 0);
                Vector3 touchDelta = touchPosition - touchPrevPos;

                // Apply movement speed scaling on mobile
                myCamera.transform.Translate(-touchDelta.x * movementSpeedMobile * Time.deltaTime, 
                                           -touchDelta.y * movementSpeedMobile * Time.deltaTime, 0, Space.Self);
            }
        }
    }

    private void HandlePCInput()
    {
        // Prevent interaction if over UI
        if (Input.GetMouseButtonDown(0)) isInteractingWithUI = EventSystem.current.IsPointerOverGameObject();
        if (isInteractingWithUI && Input.GetMouseButtonUp(0)) isInteractingWithUI = false;
        if (isInteractingWithUI) return;

        // Rotation with Left Mouse Button (using PC rotation speed)
        if (Input.GetMouseButton(0))
        {
            float rotX = -Input.GetAxis("Mouse X") * rotationSpeedPC;
            float rotY = Input.GetAxis("Mouse Y") * rotationSpeedPC;
            children.Rotate(Vector3.up * rotX, Space.World);
            if (ModelOrganizer.models[ModelOrganizer.listPtr].GetComponent<ModelInfo>().shouldSeeUnderside)
                children.Rotate(Vector3.right * rotY, Space.World);
        }

        // Right Mouse Button movement (using PC movement speed)
        if (Input.GetMouseButton(1))
        {
            float moveX = Input.GetAxis("Mouse X") * Time.deltaTime * movementSpeedPC;
            float moveY = Input.GetAxis("Mouse Y") * Time.deltaTime * movementSpeedPC;

            myCamera.transform.Translate(-moveX, -moveY, 0, Space.Self);
        }

        // Inverted zoom with Mouse Scroll Wheel (using PC zoom speed)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            zoomAmount -= scroll * zoomSpeedPC; // Inverted zoom direction
            myCamera.transform.Translate(0, 0, scroll * zoomSpeedPC * 5f, Space.Self); // Inverted zoom direction
        }
    }

    private void ResetToDefault()
    {
        myCamera.transform.position = defaultPosition;
        children.rotation = defaultRotation;
        zoomAmount = 0f;
    }
}
