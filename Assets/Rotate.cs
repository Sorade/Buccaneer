using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    [SerializeField]
    private Vector3 axis;
    [SerializeField]
    private float angularSpeed;
    [SerializeField]
    private Space space;

	void Update () {
        transform.Rotate(axis, angularSpeed*Time.deltaTime, space);
	}
}
