using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlottillaController : MonoBehaviour {
    public LayerMask mvtMask;
    private Port[] ports;     

    // Use this for initialization
    void Start()
    {
        ports = GetComponent<FlottillaSpawner>().ports;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ports.Length; i++)
        {
            foreach (var f in ports[i].dockedFlotillas)
            {
                f.agent.SetDestination(f.destination.position);
                ports[i].dockedFlotillas.Remove(f);
            }            
        }
    }
}
