using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlottillaStats : MonoBehaviour {
    public FlottillaBlueprint bp;
    [HideInInspector]
    public Mission mission;
    [HideInInspector]
    public float stayDelay;
    [HideInInspector]
    public int gold;
    [HideInInspector]
    public int cannons;

    void Start()
    {
        SetUp();
    }

    public void SetUp() {
        mission = bp.mission;
        stayDelay = bp.stayDelay;
        gold = bp.gold;
        cannons = bp.cannons;
    }
}
