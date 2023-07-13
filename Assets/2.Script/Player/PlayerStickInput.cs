using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerStickInput : MonoBehaviour, IMoveDirection, IEndDragHandler, IDragHandler
{
    [SerializeField][Min(0)] private float movementRange = 50;

    RectTransform rectTransform;

    [SerializeField]
    Vector2 startPosition;

    [SerializeField] Text text;

    public Vector2 MoveDirection
    {
        get
        {
            return ((Vector2)rectTransform.anchoredPosition - startPosition).normalized;
        }
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        startPosition = rectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        MoveStick(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = startPosition;
    }

    private void MoveStick(Vector2 screenPosition)
    {
        Vector2 delta = screenPosition - startPosition;
        delta = Vector2.ClampMagnitude(delta, movementRange);
        rectTransform.anchoredPosition = startPosition + delta;
    }
}
