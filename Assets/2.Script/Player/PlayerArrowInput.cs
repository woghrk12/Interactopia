using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerArrowInput : MonoBehaviour, IMoveDirection
{
    private Vector2 moveDirection;
    public Vector2 MoveDirection
    {
        get
        {
            return moveDirection;
        }
    }
    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        Vector2 input = callbackContext.ReadValue<Vector2>();
        moveDirection = new Vector2(input.x, input.y);
    }
}
