using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSStatus : MonoBehaviour
{
    [SerializeField] private int fontSize;
    [SerializeField] private Color fontColor = Color.green;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void OnGUI()
    {
        Rect position = new(30, 30, Screen.width, Screen.height);
        GUIStyle style = new();

        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = fontSize;
        style.normal.textColor = fontColor;

        float fps = 1.0f / Time.deltaTime;
        float frameGapMSEC = Time.deltaTime * 1000.0f;
        string FPSText = string.Format("{0:N1} FPS ({1:N1}ms)", fps, frameGapMSEC);
        GUI.Label(position, FPSText, style);
    }
}
