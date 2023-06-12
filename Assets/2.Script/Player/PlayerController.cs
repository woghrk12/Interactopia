using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }
    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        MoveDirection=new Vector2(input.x,input.y);
    }
}
