using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private Camera mainCamera;
    public Vector2 MoveDirection { get; private set; }

    [SerializeField] private float moveSpeed;
    private Vector2 targetPosition;
    private bool isPressed = false;
    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }
    private void MoveCharacter()
    {
        if (!isPressed){ return; }
        else if (Vector2.SqrMagnitude(targetPosition - (Vector2)transform.position) < 0.1) { return; }

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
        targetPosition = mainCamera.ScreenToWorldPoint(input);
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
