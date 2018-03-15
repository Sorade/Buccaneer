using UnityEngine;
using UnityEngine.AI;

public class AgentRadiusSetter : MonoBehaviour {
    public NavMeshAgent agent;
    public float radius;
    	
	[ContextMenu("Set radius")]
	void SetRadius () {
        agent.radius = radius;
	}
}
