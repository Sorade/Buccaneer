using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public int maxFlottillas;
    public int flottillaInGame;
    private PortController[] allPorts;

    // Use this for initialization
    void Start () {
        GameObject[] allPortGOs = GameObject.FindGameObjectsWithTag("Port");
        allPorts = new PortController[allPortGOs.Length];
        for (int i = 0; i < allPortGOs.Length; i++ )
        {
            PortController pc = allPortGOs[i].GetComponent<PortController>();
            if (pc != null)
            {
                allPorts[i] = pc;
            }

            if (allPortGOs.Length != allPorts.Length)
            {
                Debug.LogWarning("Some objects are missing 'Port' tags, or some non-port GO have the 'Port' tag.");
            }
        }

    }

    // Update is called once per frame
    void Update() {
        if (flottillaInGame < maxFlottillas)
        {
            int randIndex = Random.Range(0, allPorts.Length);
            allPorts[randIndex].SpawnFlottilla();
        }
    }        
}
