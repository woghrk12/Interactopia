using UnityEngine;

public class MissionBase : MonoBehaviour
{
    public bool IsNearestMission
    {
        get
        {
            return isNearestMission;
        }
        set
        {
            isNearestMission = value;

            if (isNearestMission) { sprite.color = Color.yellow; }
            else { sprite.color = Color.white; }
        }
    }

    private SpriteRenderer sprite;
    private bool isNearestMission;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
}
