using UnityEngine;
using UnityEngine.EventSystems;

public class BottomSheetController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform bottomSheet; // Referenz zum BottomSheet Panel (im Inspector zuweisen)
    [SerializeField] private float maxPosition = 0f; // Maximale Position (offen)
    [SerializeField] private float minPosition = -800f; // Minimale Position (geschlossen)
    [SerializeField] private float snapSpeed = 5f; // Geschwindigkeit der Animation

    private void Awake()
    {
        // Sicherstellen, dass die Referenz korrekt gesetzt ist
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

        // Startposition für das BottomSheet (geschlossen)
        bottomSheet.anchoredPosition = new Vector2(0, minPosition);

        // Debug: Log der initialen Position
        Debug.Log($"BottomSheet initial position: {bottomSheet.anchoredPosition}");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (bottomSheet == null) return;

        // Panel basierend auf der Mausbewegung verschieben
        float newY = Mathf.Clamp(bottomSheet.anchoredPosition.y + eventData.delta.y, minPosition, maxPosition);
        bottomSheet.anchoredPosition = new Vector2(0, newY);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (bottomSheet == null) return;

        // Entscheide, ob das Panel geöffnet oder geschlossen wird
        if (bottomSheet.anchoredPosition.y > (maxPosition + minPosition) / 2)
        {
            StartCoroutine(SnapToPosition(maxPosition));
        }
        else
        {
            StartCoroutine(SnapToPosition(minPosition));
        }
    }

    private System.Collections.IEnumerator SnapToPosition(float targetPosition)
    {
        if (bottomSheet == null) yield break;

        while (Mathf.Abs(bottomSheet.anchoredPosition.y - targetPosition) > 1f)
        {
            float newY = Mathf.Lerp(bottomSheet.anchoredPosition.y, targetPosition, Time.deltaTime * snapSpeed);
            bottomSheet.anchoredPosition = new Vector2(0, newY);
            yield return null;
        }

        bottomSheet.anchoredPosition = new Vector2(0, targetPosition);
    }
}
