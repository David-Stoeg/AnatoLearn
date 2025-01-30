using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class BottomSheetController2 : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform bottomSheet;
    [SerializeField] private float maxPosition = 350f; // Offen
    [SerializeField] private float midPosition = 100f; // Optionale Zwischenposition
    [SerializeField] private float minPosition = -270f; // Komplett versteckt
    [SerializeField] private float snapSpeed = 5f;

    private bool isActive = true; // Startet als 'aktiv', Bottom Sheet ist offen

    private void Start()
    {
        if (bottomSheet == null) return;

        // Beim Start direkt oben platzieren
        bottomSheet.gameObject.SetActive(true); // **Immer sichtbar**
        bottomSheet.anchoredPosition = new Vector2(0, maxPosition); // **Direkt auf maxPosition (aufgeklappt)**
    }

    // Funktion, um das Bottom Sheet zu öffnen (wenn auf Explore geklickt wird)
    public void ShowBottomSheet()
    {
        Debug.Log("ShowBottomSheet called");

        // Stoppe alle laufenden Animationen und fahre das Bottom Sheet nach oben
        StopAllCoroutines();
        StartCoroutine(SnapToPosition(maxPosition)); // **Immer nach oben fahren**
        isActive = true; // Es ist jetzt aktiv
    }

    // Funktion, um das Bottom Sheet zu schließen (wenn es runtergezogen wird)
    public void HideBottomSheet()
    {
        StopAllCoroutines(); // Stoppe alle Animationen
        StartCoroutine(SnapToPosition(minPosition, true)); // **Nach unten fahren und deaktivieren**
        isActive = false;
    }

    // Dragging des Panels (Wenn man das Bottom Sheet zieht)
    public void OnDrag(PointerEventData eventData)
    {
        if (bottomSheet == null) return;

        // Berechne die neue Y-Position basierend auf der Drag-Distanz
        float newY = Mathf.Clamp(bottomSheet.anchoredPosition.y + eventData.delta.y, minPosition, maxPosition);
        bottomSheet.anchoredPosition = new Vector2(0, newY);
    }

    // Nachdem das Dragging endet (Wenn das Ziehen gestoppt wird)
    public void OnEndDrag(PointerEventData eventData)
    {
        if (bottomSheet == null) return;

        float currentY = bottomSheet.anchoredPosition.y;
        float halfway = (maxPosition + minPosition) / 2;

        if (currentY > halfway)
        {
            StartCoroutine(SnapToPosition(maxPosition)); // Wenn es mehr als die Hälfte hochgezogen wurde, nach oben fahren
        }
        else
        {
            HideBottomSheet(); // Wenn es weniger als die Hälfte hochgezogen wurde, nach unten fahren
        }
    }

    // Sanfte Bewegung des Panels zu einer Zielposition (max oder min)
    private IEnumerator SnapToPosition(float targetPosition, bool deactivateOnEnd = false)
    {
        if (bottomSheet == null) yield break;

        while (Mathf.Abs(bottomSheet.anchoredPosition.y - targetPosition) > 1f)
        {
            // Animation zur Zielposition
            float newY = Mathf.Lerp(bottomSheet.anchoredPosition.y, targetPosition, Time.deltaTime * snapSpeed);
            bottomSheet.anchoredPosition = new Vector2(0, newY);
            yield return new WaitForEndOfFrame();
        }

        // Zielposition endgültig setzen
        bottomSheet.anchoredPosition = new Vector2(0, targetPosition);

        if (deactivateOnEnd)
        {
            bottomSheet.gameObject.SetActive(false); // Deaktivieren, wenn am unteren Ende
            isActive = false;
        }
    }
}
