using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlottillaMotor : MonoBehaviour {
    private NavMeshAgent agent;

    // Use this for initialization
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void SetRandomDest()
    {
        GameObject[] allPorts = GameObject.FindGameObjectsWithTag("Port");
        MoveToPoint(allPorts[Random.Range(0, allPorts.Length)].transform.position);
    }
}
