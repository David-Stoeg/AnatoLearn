using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class BottomSheetController2 : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform bottomSheet; // Referenz zum BottomSheet Panel (im Inspector zuweisen)
    [SerializeField] private float maxPosition = 350f; // Maximale Position (offen, 350)
    [SerializeField] private float minPosition = -800f; // Minimale Position (geschlossen, -800)
    [SerializeField] private float snapSpeed = 5f; // Geschwindigkeit der Animation

    private void Awake()
    {
        if (bottomSheet == null)
        {
            bottomSheet = GetComponent<RectTransform>();
            if (bottomSheet == null)
            {
                Debug.LogError("BottomSheet reference is not assigned in the Inspector and could not be found on this GameObject.");
            }
        }
    }

    private void Start()
    {
        if (bottomSheet == null) return;

        // Stelle sicher, dass das BottomSheet beim Start auf die `minPosition` gesetzt wird (geschlossen)
        bottomSheet.anchoredPosition = new Vector2(0, minPosition);
        Debug.Log("BottomSheet initial position: " + bottomSheet.anchoredPosition);
    }

    // Wird aufgerufen, wenn der Explore-Button geklickt wird
    public void ShowBottomSheet()
    {
        Debug.Log("ShowBottomSheet called");

        // Stoppe alle laufenden Animationen, falls eine aktiv ist
        StopAllCoroutines();

        // Stelle sicher, dass das Bottom Sheet zu Beginn geschlossen ist
        bottomSheet.anchoredPosition = new Vector2(0, minPosition);

        // Starte die Coroutine, die das Bottom Sheet von der minPosition zu maxPosition (geöffnet) bewegt
        StartCoroutine(SnapToPosition(maxPosition));
    }

    // Wird aufgerufen, wenn das BottomSheet geschlossen werden soll
    public void HideBottomSheet()
    {
        StopAllCoroutines(); // Stoppe alle laufenden Animationen
        StartCoroutine(SnapToPosition(minPosition)); // Animation, um das BottomSheet nach unten zu bewegen
    }

    // Diese Methode wird beim Draggen des Panels aufgerufen
    public void OnDrag(PointerEventData eventData)
    {
        if (bottomSheet == null) return;

        // Berechnet die neue Y-Position basierend auf der Drag-Distanz
        float newY = Mathf.Clamp(bottomSheet.anchoredPosition.y + eventData.delta.y, minPosition, maxPosition);
        bottomSheet.anchoredPosition = new Vector2(0, newY);
    }

    // Diese Methode wird nach dem Draggen aufgerufen
    public void OnEndDrag(PointerEventData eventData)
    {
        if (bottomSheet == null) return;

        // Wenn das Bottom Sheet mehr als die Hälfte nach oben gezogen wird, soll es offen bleiben
        if (bottomSheet.anchoredPosition.y > (maxPosition + minPosition) / 2)
        {
            ShowBottomSheet(); // Öffnen
        }
        else
        {
            HideBottomSheet(); // Schließen
        }
    }

    // Sanfte Bewegung des Panels zur Zielposition (max oder min)
    private IEnumerator SnapToPosition(float targetPosition)
    {
        if (bottomSheet == null) yield break;

        // Solange die aktuelle Position nicht die Zielposition erreicht hat
        while (Mathf.Abs(bottomSheet.anchoredPosition.y - targetPosition) > 1f)
        {
            // Bewegung zur Zielposition
            float newY = Mathf.Lerp(bottomSheet.anchoredPosition.y, targetPosition, Time.deltaTime * snapSpeed);
            bottomSheet.anchoredPosition = new Vector2(0, newY);
            yield return null; // Warten auf den nächsten Frame
        }

        // Endgültig sicherstellen, dass das Ziel erreicht wurde
        bottomSheet.anchoredPosition = new Vector2(0, targetPosition);
        Debug.Log("BottomSheet final position: " + bottomSheet.anchoredPosition);
    }
}
