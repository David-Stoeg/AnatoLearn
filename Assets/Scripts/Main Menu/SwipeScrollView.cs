using UnityEngine;
using UnityEngine.UIElements;

public class SwipeScrollView : MonoBehaviour
{
    private ScrollView scrollView;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private float screenWidth;
    private int currentPage = 0;
    private int maxPages = 1; // Anzahl der "Seiten" (immer 2 Buttons pro Seite)

    void Start()
    {
        // UI-Dokument abrufen
        var root = GetComponent<UIDocument>().rootVisualElement;
        scrollView = root.Q<ScrollView>();

        // Bildschirmbreite / 2 weil immer 2 Buttons sichtbar sein sollen
        screenWidth = Screen.width / 2;

        // Anzahl der Seiten berechnen
        maxPages = Mathf.CeilToInt(scrollView.contentContainer.resolvedStyle.width / screenWidth) - 1;
    }

    void Update()
    {
        if (Input.touchCount == 1) // Touch-Eingabe
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                HandleSwipe();
            }
        }

        // Debug: Maus-Eingabe für Tests im Editor
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            HandleSwipe();
        }
    }

    void HandleSwipe()
    {
        float deltaX = endTouchPosition.x - startTouchPosition.x;

        if (Mathf.Abs(deltaX) > screenWidth * 0.2f) // Falls Wischbewegung groß genug ist
        {
            if (deltaX < 0 && currentPage < maxPages) // Nach links wischen
            {
                currentPage++;
            }
            else if (deltaX > 0 && currentPage > 0) // Nach rechts wischen
            {
                currentPage--;
            }

            MoveToPage(currentPage);
        }
    }

    private void MoveToPage(int pageIndex)
    {
        float target = pageIndex * screenWidth;
        scrollView.scrollOffset = new Vector2(target, 0);
    }
}
