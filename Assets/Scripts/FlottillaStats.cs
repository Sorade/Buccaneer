using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlottillaStats : MonoBehaviour {
    public FlottillaBlueprint bp;
    [HideInInspector]
    public Mission mission;
    [HideInInspector]
    public int gold;
    [HideInInspector]
    public int cannons;
    [HideInInspector]
    public float speed;

    void Awake()
    {
        SetUp();
    }

    public void SetUp() {
        mission = bp.mission;
        gold = bp.gold;
        cannons = bp.cannons;
        speed = bp.speed;

        AddBehaviour();
    }

    void AddBehaviour()
    {
        switch (mission)
        {
            case Mission.MERCHANT:
                break;
            case Mission.HUNTER:
                gameObject.AddComponent<HunterBehaviour>();
                break;
            case Mission.PLAYER:
                break;
            default:
                break;
        }
    }
}
