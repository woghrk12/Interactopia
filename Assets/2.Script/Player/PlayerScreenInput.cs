using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScreenInput : MonoBehaviour, IMoveDirection
{
    private Camera mainCamera;

    private Vector2 targetPosition, targetDirection;
    public Vector2 MoveDirection
    {
        get
        {
            if (!isPressed || Vector2.SqrMagnitude(targetPosition - (Vector2)transform.position) < 0.1)
            {
                return Vector2.zero;
            }

            return targetDirection;
        }
    }
    private bool isPressed = false;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnPosition(InputAction.CallbackContext callbackContext)
    {
        Vector2 input = callbackContext.ReadValue<Vector2>();
        targetPosition = mainCamera.ScreenToWorldPoint(input);
        targetDirection = (targetPosition - (Vector2)transform.position).normalized;
    }

    public void OnPress(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed || callbackContext.started)
        {
            isPressed = true;
        }
        else if (callbackContext.canceled)
        {
            isPressed = false;
        }
    }
}
