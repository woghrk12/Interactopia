using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }
    private Vector2 targetPosition;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rigid2D;
    private bool isPressed = false;
    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        if (!isPressed )
        {
            return;
        }
        else if (Vector2.Distance(targetPosition, transform.position) < 0.1)
        {
            return;
        }
        rigid2D.MovePosition(rigid2D.position + moveSpeed * Time.fixedDeltaTime * MoveDirection);
    }
    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed || callbackContext.started)
        {
            targetPosition = Vector2.positiveInfinity;
            isPressed = true;
        }
        if (callbackContext.canceled)
        {
            isPressed = false;
        }
        Vector2 input = callbackContext.ReadValue<Vector2>();
        MoveDirection = new Vector2(input.x, input.y);
    }
    public void OnPosition(InputAction.CallbackContext callbackContext)
    {
        Vector2 input = callbackContext.ReadValue<Vector2>();
        targetPosition = Camera.main.ScreenToWorldPoint(input);
        Vector2 targetDirection = (targetPosition - (Vector2)transform.position).normalized;
        MoveDirection = targetDirection;
    }
    public void OnPress(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed || callbackContext.started)
        {
            isPressed = true;
        }
        if (callbackContext.canceled)
        {
            isPressed = false;
        }
    }
}
