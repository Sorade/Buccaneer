using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterBehaviour : Behaviour {
    public float scanRadius = 10f;
    private Transform player;
    private FlottillaMotor motor;
    private bool isOnHunt = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        motor = GetComponent<FlottillaMotor>();
    }

    public override void MissionRoutine()
    {
        if (Vector3.Distance(transform.position, player.position) <= scanRadius)
        {
            motor.MoveToPoint(player.position);
            isOnHunt = true;
        } else if (isOnHunt){
            isOnHunt = false;
            motor.SetRandomDest();
        }
    }
}
