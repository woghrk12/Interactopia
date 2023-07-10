using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

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
        List<InputDevice> devices = new();

        foreach (InputDevice device in InputSystem.devices)
        {
            if (device.displayName.ToUpper().Contains(inputMode.ToString()))
            {
                devices.Add(device);
            }
        }

        InputDevice[] deviceArray = devices.ToArray();

        switch (inputMode)
        {
            case EInputMode.KEYBOARD:
                input = playerArrowInput;
                playerInput.SwitchCurrentControlScheme("Keyboard", deviceArray);
                break;

            case EInputMode.MOUSE:
                input = playerScreenInput;
                playerInput.SwitchCurrentControlScheme("Mouse", deviceArray);
                break;

            case EInputMode.GAMEPAD:
                input = playerArrowInput;
                playerInput.SwitchCurrentControlScheme("Gamepad", deviceArray);
                break;

            case EInputMode.TOUCH:
                input = playerScreenInput;
                playerInput.SwitchCurrentControlScheme("Touch", deviceArray);
                break;
        }
    }
}
