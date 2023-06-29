using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerArrowInput), typeof(PlayerScreenInput), typeof(CharacterMovement))]
public class PlayerController : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    private enum EInputMode
    {
        Arrow,
        Sceen
    }

    [SerializeField] private EInputMode inputMode;
    IMoveDirection input;
    IMoveDirection playerArrowInput, playerScreenInput;

    CharacterMovement characterMovement;

    // temp test code
    private void Update()
    {
        if (!photonView.IsMine)
            return;

        switch (inputMode)
        {
            case EInputMode.Arrow:
                input = playerArrowInput;
                break;

            case EInputMode.Sceen:
                input = playerScreenInput;
                break;
        }

        characterMovement.MoveDirection = input.MoveDirection;
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        playerArrowInput = GetComponent<PlayerArrowInput>();
        playerScreenInput = GetComponent<PlayerScreenInput>();
        characterMovement = GetComponent<CharacterMovement>();

        if (!photonView.IsMine)
        {
            Destroy(this);
        }
        else
        {
            input = playerArrowInput; //temp maybe change to auto-detect later
        }
    }
    private void OnDestroy()
    {
        Destroy((PlayerArrowInput)playerArrowInput);
        Destroy((PlayerScreenInput)playerScreenInput);
        Destroy(characterMovement);
        Destroy(GetComponent<PlayerInput>());
    }
}
