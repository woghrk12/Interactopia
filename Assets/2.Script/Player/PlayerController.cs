using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }
    [SerializeField] float _moveSpeed;
    Rigidbody2D _rigidbody2D;
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + MoveDirection * _moveSpeed);
    }
    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        MoveDirection = new Vector2(input.x, input.y);
    }
}
