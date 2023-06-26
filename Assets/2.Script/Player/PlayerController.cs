using UnityEngine;

[RequireComponent(typeof(PlayerArrowInput), typeof(PlayerScreenInput), typeof(CharacterMovement))]
public class PlayerController : MonoBehaviour
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
    private void Awake()
    {
        playerArrowInput = GetComponent<PlayerArrowInput>();
        playerScreenInput = GetComponent<PlayerScreenInput>();
        characterMovement = GetComponent<CharacterMovement>();
        input = playerArrowInput; //temp maybe change to auto-detect later
    }
    // temp test code
    private void Update()
    {
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

}
