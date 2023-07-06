using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice;
using Photon.Voice.PUN;
using Photon.Voice.Unity;

public class PhotonVoiceController : MonoBehaviour
{
    Recorder recorder;
    private void Awake()
    {
        recorder = GetComponent<Recorder>();
    }

    void Update()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.Space))
        {
            recorder.TransmitEnabled = !recorder.TransmitEnabled;
        }
    }
}
