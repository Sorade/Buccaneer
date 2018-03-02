using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public Transform player;
    private float initialY;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialY = transform.position.y;
	}
	
	void Update () {
        transform.position = new Vector3(player.position.x, initialY, player.position.z) ;
	}
}
