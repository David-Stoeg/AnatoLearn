using UnityEngine;
using UnityEngine.EventSystems;

public class ModelInspector : MonoBehaviour
{
    public Transform children; // The object to rotate
    public Camera myCamera; // The main camera
    public float speed = 10f; // Rotation and movement speed
    public float scrollSpeed = 2f; // Zoom speed
    public float climbSpeed = 5f; // Speed for vertical movement
    private float zoomAmount = 0f; // Current zoom level
    private bool isInteractingWithUI = false; // Prevent interaction if over UI

    // Store default values for position, rotation, and zoom
    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    private float defaultZoomAmount;

    private void Start()
    {
        // Store the default values when the scene starts
        defaultPosition = myCamera.transform.position;
        defaultRotation = children.rotation;
        defaultZoomAmount = zoomAmount;
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

        // Reset to default position, rotation, and zoom when the "R" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetToDefault();
        }
    }

    private void HandlePCInput()
    {
        // Skip interaction if over UI
        if (Input.GetMouseButtonDown(0)) isInteractingWithUI = EventSystem.current.IsPointerOverGameObject();
        if (isInteractingWithUI && Input.GetMouseButtonUp(0)) isInteractingWithUI = false;
        if (isInteractingWithUI) return;

        // Rotation (Left Mouse Button)
        if (Input.GetMouseButton(0))
        {
            float rotX = -Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            float rotY = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;

            children.Rotate(Vector3.up * rotX, Space.World);
            if (ModelOrganizer.models[ModelOrganizer.listPtr].GetComponent<ModelInfo>().shouldSeeUnderside)
                children.Rotate(Vector3.right * rotY, Space.World);
        }

        // Movement (Right Mouse Button) - scaled with zoom
        if (Input.GetMouseButton(1))
        {
            // Apply zoom-based scaling to the movement
            float zoomFactor = Mathf.Lerp(1f, 0.1f, Mathf.InverseLerp(-10f, 1f, zoomAmount));
            float moveX = Input.GetAxis("Mouse X") * Time.deltaTime * speed * 0.1f * zoomFactor;
            float moveY = Input.GetAxis("Mouse Y") * Time.deltaTime * speed * 0.1f * zoomFactor;

            // Apply the movement with the zoom factor
            myCamera.transform.Translate(-moveX, -moveY, 0, Space.Self);
        }

        // Zoom (Mouse Scroll Wheel)
        zoomAmount += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        myCamera.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, Space.Self);

        // Movement keys
        if (Input.GetKeyDown(KeyCode.W)) ResetZoom();
        if (Input.GetKeyDown(KeyCode.S)) children.rotation = Quaternion.identity;

        if (Input.GetKey(KeyCode.Q)) myCamera.transform.position += myCamera.transform.up * climbSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) myCamera.transform.position -= myCamera.transform.up * climbSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    private void HandleTouchInput()
    {
        // Debugging touch count
        Debug.Log("Touch count: " + Input.touchCount);

        // Single touch: Rotation gesture
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotX = -touch.deltaPosition.x * speed * Time.deltaTime;
                float rotY = touch.deltaPosition.y * speed * Time.deltaTime;

                // Rotate the object
                children.Rotate(Vector3.up * rotX, Space.World);
                if (ModelOrganizer.models[ModelOrganizer.listPtr].GetComponent<ModelInfo>().shouldSeeUnderside)
                    children.Rotate(Vector3.right * rotY, Space.World);

                // Debugging touch move
                Debug.Log("Touch Moved: " + touch.deltaPosition);
            }
        }

        // Two touches: Pinch to zoom and two-finger drag
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Detect Pinch Zoom
            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            zoomAmount += deltaMagnitudeDiff * 0.01f; // Adjust sensitivity
            zoomAmount = Mathf.Clamp(zoomAmount, -10f, 1f); // Adjust zoom limits

            // Apply zoom to camera
            myCamera.transform.Translate(0, 0, -deltaMagnitudeDiff * scrollSpeed * 0.1f, Space.Self);

            // Detect Two-Finger Drag for camera movement
            Vector2 averageDelta = (touch0.deltaPosition + touch1.deltaPosition) * 0.5f;
            myCamera.transform.Translate(-averageDelta.x * 0.01f, -averageDelta.y * 0.01f, 0, Space.Self);

            // Debugging pinch zoom
            Debug.Log("Pinch Zoom: " + deltaMagnitudeDiff);
        }

        // Reset zoom on double tap
        if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 2) ResetZoom();
    }

    private void ResetZoom()
    {
        zoomAmount = 0f;
        myCamera.transform.localPosition = Vector3.zero;
    }

    private void ResetToDefault()
    {
        // Reset position, rotation, and zoom to their default values
        myCamera.transform.position = defaultPosition;
        children.rotation = defaultRotation;
        zoomAmount = defaultZoomAmount;
        myCamera.transform.localPosition = Vector3.zero; // Ensure camera position is reset if needed
    }
}
