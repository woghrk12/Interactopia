using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerScreenInput : MonoBehaviour, IMoveDirection, IPunInstantiateMagicCallback
{
    private Camera mainCamera;

    private Vector2 targetPosition, targetDirection, screenPosition;
    public Vector2 MoveDirection
    {
        get
        {
            if (!isPressed || Vector2.SqrMagnitude(targetPosition - (Vector2)transform.position) < 0.1)
            {
                return Vector2.zero;
            }

            return targetDirection;
        }
    }
    private bool isPressed = false;

    public void OnPosition(InputAction.CallbackContext callbackContext)
    {
        screenPosition = callbackContext.ReadValue<Vector2>();
        targetPosition = mainCamera.ScreenToWorldPoint(screenPosition);
        targetDirection = (targetPosition - (Vector2)transform.position).normalized;
    }

    public void OnPress(InputAction.CallbackContext callbackContext)
    {
        if (IsPointerOverUI()|| callbackContext.canceled)
        {
            isPressed = false;
        }
        else if (callbackContext.performed || callbackContext.started)
        {
            isPressed = true;
        }
    }
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        mainCamera = Camera.main;
    }
    public bool IsPointerOverUI()
    {
        PointerEventData pointerEventData = new(EventSystem.current);
        pointerEventData.position = screenPosition;

        List<RaycastResult> raycastResultsList = new();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);

        return raycastResultsList.Count > 0;
    }
}
