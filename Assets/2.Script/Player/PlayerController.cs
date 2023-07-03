using Photon.Pun;
using UnityEditor.Experimental.GraphView;
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

    PlayerInput playerInput;

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
#if UNITY_STANDALONE || UNITY_EDITOR

        inputMode = EInputMode.Arrow;
        input = playerArrowInput;
        playerInput.SwitchCurrentControlScheme("Keyboard&Mouse", Keyboard.current);

        //inputMode = EInputMode.Sceen;
        //input = playerScreenInput;
        //playerInput.SwitchCurrentControlScheme("Mouse", Mouse.current) ;

        //inputMode = EInputMode.Arrow;
        //input = playerArrowInput;
        //playerInput.SwitchCurrentControlScheme("Joystick",Gamepad.current);

#elif UNITY_ANDROID || UNITY_IOS

        inputMode = EInputMode.Sceen;
        input = playerScreenInput;
        playerInput.SwitchCurrentControlScheme("Touch", Touchscreen.current);

#endif
    }
    //PC에서도 변경시켜서 가능
    //
}
