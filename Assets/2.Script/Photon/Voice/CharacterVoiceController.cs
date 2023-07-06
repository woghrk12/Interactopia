using Photon.Pun;
using Photon.Voice.PUN;
using UnityEngine;

[RequireComponent(typeof(PhotonVoiceView))]
public class CharacterVoiceController : MonoBehaviour, IPunInstantiateMagicCallback
{
    PhotonVoiceView photonVoiceView;
    [SerializeField] GameObject recordMark;
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        photonVoiceView = GetComponent<PhotonVoiceView>();
    }

    // Update is called once per frame
    void Update()
    {
        recordMark.SetActive(photonVoiceView.IsRecording);
    }
}
