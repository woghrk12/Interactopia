using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private InGameUI inGameUI = null;

    public void OnClick(int idx)
    {
        inGameUI.TurnOnPanel((EInGamePanel)idx);
    }

    public void Connect() => NetworkManager.Connect();
}
