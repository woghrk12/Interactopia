using Photon.Pun;
using Photon.Voice.PUN;
using Photon.Voice.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PhotonVoiceView))]
public class CharacterVoiceController : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    PhotonVoiceView photonVoiceView;
    [SerializeField] GameObject recordMark;

    Recorder recorder;

    // Update is called once per frame
    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (recordMark.activeSelf != photonVoiceView.IsRecording)
        {
            photonView.RPC("SetRecordMark", RpcTarget.All, photonVoiceView.IsRecording);
        }
    }
    [PunRPC]
    private void SetRecordMark(bool isRecording)
    {
        recordMark.SetActive(isRecording);
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        photonVoiceView = GetComponent<PhotonVoiceView>();
        recorder = GameObject.FindObjectOfType<Recorder>();
    }

    public void OnVoiceChatTriggerButtonDown(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed)
        {
            return;
        }

        recorder.TransmitEnabled = !recorder.TransmitEnabled;
    }
}
