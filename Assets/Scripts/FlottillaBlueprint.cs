﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flottilla", menuName = "Blueprints/Flottilla", order = 1)]
public class FlottillaBlueprint : ScriptableObject {
    public Mission mission;
    public int gold;
    public int cannons;
    public float speed;
}
