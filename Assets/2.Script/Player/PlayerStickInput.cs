using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerStickInput : MonoBehaviour, IMoveDirection, IEndDragHandler, IDragHandler
{
    [SerializeField][Min(0)] private float movementRange = 50;

    Vector2 startPosition;

    public Vector2 MoveDirection
    {
        get
        {
            return ((Vector2)transform.position - startPosition).normalized;
        }
    }

    private void Awake()
    {
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        MoveStick(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
    }

    private void MoveStick(Vector2 position)
    {
        Vector2 delta = position - startPosition;
        delta = Vector2.ClampMagnitude(delta, movementRange);
        transform.position = startPosition + delta;
    }
}
