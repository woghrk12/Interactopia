using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    private readonly float MISSION_DISTANCE = 1.5f;

    private List<MissionBase> missions = new List<MissionBase>();
    private MissionBase selectedMission = null;

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        if (!photonView.IsMine)
        {
            Destroy(this);
        }

        AddMissions();
    }

    void Update()
    {
        CheckMission();
    }

    private void CheckMission()
    {
        float minLength = float.MaxValue;
        MissionBase nearestMission = null;

        foreach (MissionBase mission in missions)
        {
            mission.IsNearestMission = false;

            float distance = Vector2.Distance(mission.transform.position, transform.position);

            if (distance < minLength)
            {
                nearestMission = mission;
                minLength = distance;
            }
        }

        if (minLength < MISSION_DISTANCE)
        {
            selectedMission = nearestMission;
            selectedMission.IsNearestMission = true;
        }
        else
        {
            selectedMission = null;
        }
    }

    private void AddMissions()
    {
        GameObject[] missionObjects = GameObject.FindGameObjectsWithTag("mission");

        foreach (GameObject missionObj in missionObjects)
        {
            MissionBase mission = missionObj.GetComponent<MissionBase>();

            if (!mission) { continue; }

            missions.Add(mission);
        }
    }
}
