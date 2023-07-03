using UnityEngine;

public class TestInputFind : MonoBehaviour
{
    //TestScript
    PlayerController controller;
    public void Find()
    {
        controller = GameObject.FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }
    public void SwitchMode(int inputMode)
    {
        controller.SwitchInputMode((PlayerController.EInputMode)inputMode);
    }
}
