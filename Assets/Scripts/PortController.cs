using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortController : MonoBehaviour {
    public List<FlottillaController> docked;
    private Vector3[] otherPortLocs;

	// Use this for initialization
	void Start () {
        GameObject[] allPorts = GameObject.FindGameObjectsWithTag("Port");
        otherPortLocs = new Vector3[allPorts.Length-1];
        int j = 0;
        for (int i = 0; i < allPorts.Length; i++)
        {
            if (allPorts[i] != gameObject)
            {                
                otherPortLocs[j] = allPorts[i].transform.position;
                j += 1;
            }
        }
    }
	
    public Vector3 RequestDestination(Mission mission)
    {
        Debug.Log("Request dest from " + gameObject.name);
        return otherPortLocs[ Random.Range(0, otherPortLocs.Length)];
    }

}
