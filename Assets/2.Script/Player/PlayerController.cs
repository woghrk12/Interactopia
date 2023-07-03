using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerArrowInput), typeof(PlayerScreenInput), typeof(CharacterMovement))]
public class PlayerController : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    public enum EInputMode
    {
        KEYBOARD,
        MOUSE,
        GAMEPAD,
        TOUCH
    }

    PlayerInput playerInput;

    IMoveDirection input;
    IMoveDirection playerArrowInput, playerScreenInput;

    CharacterMovement characterMovement;

    // temp test code
    private void Update()
    {
        if (!photonView.IsMine)
            return;

        characterMovement.MoveDirection = input.MoveDirection;
    }

    private void OnDestroy()
    {
        Destroy((PlayerArrowInput)playerArrowInput);
        Destroy((PlayerScreenInput)playerScreenInput);
        Destroy(characterMovement);
        Destroy(playerInput);
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        playerArrowInput = GetComponent<PlayerArrowInput>();
        playerScreenInput = GetComponent<PlayerScreenInput>();
        characterMovement = GetComponent<CharacterMovement>();
        playerInput = GetComponent<PlayerInput>();

        if (!photonView.IsMine)
        {
            Destroy(this);
        }
        else
        {
            InitPlayerInput();
        }
    }

    private void InitPlayerInput()
    {
        // PC
#if UNITY_STANDALONE || UNITY_EDITOR

        SwitchInputMode(EInputMode.KEYBOARD);

        // Mobile
#elif UNITY_ANDROID || UNITY_IOS

        SwitchInputMode(EInputMode.TOUCH);

#endif
    }

    public void SwitchInputMode(EInputMode inputMode)
    {
        switch (inputMode)
        {
            case EInputMode.KEYBOARD:
                input = playerArrowInput;
                playerInput.SwitchCurrentControlScheme("Keyboard", Keyboard.current);
                break;

            case EInputMode.MOUSE:
                input = playerScreenInput;
                playerInput.SwitchCurrentControlScheme("Mouse", Mouse.current);
                break;

            case EInputMode.GAMEPAD:
                input = playerScreenInput;
                playerInput.SwitchCurrentControlScheme("Mouse", Mouse.current);
                break;

            case EInputMode.TOUCH:
                input = playerScreenInput;
                playerInput.SwitchCurrentControlScheme("Touch", Touchscreen.current);
                break;
        }
    }
}
