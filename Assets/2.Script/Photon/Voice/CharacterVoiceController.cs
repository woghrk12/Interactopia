using Photon.Pun;
using Photon.Voice.PUN;
using UnityEngine;

[RequireComponent(typeof(PhotonVoiceView))]
public class CharacterVoiceController : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    PhotonVoiceView photonVoiceView;
    [SerializeField] GameObject recordMark;
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        photonVoiceView = GetComponent<PhotonVoiceView>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        if (recordMark.activeSelf != photonVoiceView.IsRecording)
            photonView.RPC("SetRecordMark", RpcTarget.All, photonVoiceView.IsRecording);
    }
    [PunRPC]
    private void SetRecordMark(bool isRecording)
    {
        recordMark.SetActive(isRecording);
    }
}
