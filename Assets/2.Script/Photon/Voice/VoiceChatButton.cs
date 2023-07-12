using Photon.Voice.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

public class VoiceChatButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Recorder recorder;

    public void OnPointerDown(PointerEventData eventData)
    {
        recorder.TransmitEnabled = !recorder.TransmitEnabled;
    }
}
