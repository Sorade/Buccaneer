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
    public float gold;

    // Use this for initialization
    void Start () {
        mission = bp.mission;
        stayDelay = bp.stayDelay;
        gold = bp.gold;

    }
}
