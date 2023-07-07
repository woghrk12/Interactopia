using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

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

    InputDevice lastUsedDevice;

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
        InputSystem.onEvent -= OnDeviceChanged;
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
        InputSystem.onEvent += OnDeviceChanged;
        // Mobile
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

        SwitchInputMode(EInputMode.TOUCH);

        // PC
#elif UNITY_STANDALONE || UNITY_EDITOR

        SwitchInputMode(EInputMode.KEYBOARD);

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
                input = playerArrowInput;
                playerInput.SwitchCurrentControlScheme("Gamepad", Gamepad.current);
                break;

            case EInputMode.TOUCH:
                input = playerScreenInput;
                playerInput.SwitchCurrentControlScheme("Touch", Touchscreen.current);
                break;
        }
    }

    public void OnDeviceChanged(InputEventPtr inputEventPtr, InputDevice inputDevice)
    {
        if (lastUsedDevice == inputDevice || playerInput.devices[0].displayName != inputDevice.displayName)
        {
            return;
        }
        playerInput.SwitchCurrentControlScheme(inputDevice);
        lastUsedDevice = inputDevice;
    }
}
