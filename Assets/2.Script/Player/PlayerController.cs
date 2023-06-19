using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rigid2D;
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
        rigid2D.MovePosition(rigid2D.position + moveSpeed * Time.fixedDeltaTime * MoveDirection);
    }
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        MoveDirection = new Vector2(input.x, input.y);
    }
}
