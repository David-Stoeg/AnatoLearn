/*

using UnityEngine;

public class ModelViewer : MonoBehaviour
{
    public float rotateSpeed = 5.0f;
    public float zoomSpeed = 5.0f;
    public float minZoomDistance = 1.0f;
    public float maxZoomDistance = 10.0f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float zoomDistance;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        zoomDistance = maxZoomDistance; // Start with max zoom distance
        UpdateCameraPosition();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // PC Controls
        if (Input.GetMouseButton(0)) // Left mouse button for rotation
        {
            float rotationX = Input.GetAxis("Mouse X") * rotateSpeed; // Right = Positive
            float rotationY = Input.GetAxis("Mouse Y") * rotateSpeed; // Up = Positive
            transform.Rotate(rotationY, -rotationX, 0); // Normal Y rotation, inverted X rotation
        }

        if (Input.GetMouseButton(1)) // Right mouse button for moving
        {
            float moveX = Input.GetAxis("Mouse X") * zoomSpeed * Time.deltaTime; // Right = Positive
            float moveY = Input.GetAxis("Mouse Y") * zoomSpeed * Time.deltaTime; // Up = Positive
            
            // Move the camera instead of the object
            Camera.main.transform.Translate(-moveX, -moveY, 0, Space.World);
        }

        if (Input.GetMouseButtonDown(2)) // Middle mouse button for reset
        {
            ResetView();
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Mouse wheel for zoom
        if (scroll != 0f)
        {
            Zoom(scroll);
        }

        // Mobile Controls
        if (Input.touchCount == 1)
        {
            // Rotate with one finger
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotationX = touch.deltaPosition.x * rotateSpeed * Time.deltaTime; // Right = Positive
                float rotationY = touch.deltaPosition.y * rotateSpeed * Time.deltaTime; // Up = Positive
                transform.Rotate(rotationY, -rotationX, 0); // Normal Y rotation, inverted X rotation
            }
        }
        else if (Input.touchCount == 2)
        {
            // Move with two fingers
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
            {
                Vector2 delta1 = touch1.deltaPosition;
                Vector2 delta2 = touch2.deltaPosition;
                Vector2 delta = (delta1 + delta2) / 2;

                // Move the camera instead of the object
                Camera.main.transform.Translate(-delta.x * zoomSpeed * Time.deltaTime, -delta.y * zoomSpeed * Time.deltaTime, 0, Space.World);
            }
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 2) // Double-tap to reset
        {
            ResetView();
        }
    }

    void Zoom(float scroll)
    {
        // Adjust zoom distance
        zoomDistance -= scroll * zoomSpeed;
        zoomDistance = Mathf.Clamp(zoomDistance, minZoomDistance, maxZoomDistance);

        // Update the camera's position based on the zoom distance
        Camera.main.transform.position = initialPosition - Camera.main.transform.forward * zoomDistance; // Keep camera at zoom distance
    }

    void ResetView()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        zoomDistance = maxZoomDistance; // Reset zoom distance
        UpdateCameraPosition(); // Reset camera position
    }

    void UpdateCameraPosition()
    {
        Camera.main.transform.position = initialPosition - Camera.main.transform.forward * zoomDistance; // Reset camera position
    }
}

*/
