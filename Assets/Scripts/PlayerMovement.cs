using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour {
    private Camera cam;
    public LayerMask mvtMask;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start () {
        cam = Camera.main;
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50, mvtMask))
            {
                MoveToPoint(hit.point);
            }
        }
	}

    void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
