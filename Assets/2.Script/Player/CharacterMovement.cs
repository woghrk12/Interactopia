using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour, IPunInstantiateMagicCallback
{
    private Rigidbody2D rigid2D;

    public Vector2 MoveDirection { private get; set; }
    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        rigid2D.MovePosition(rigid2D.position + moveSpeed * Time.fixedDeltaTime * MoveDirection);
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
}
