using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flotilla
{
    public Port origin;
    public Port destination;
    public GameObject go;
    public NavMeshAgent agent;

    public Flotilla(Port originPort, Port destPort, GameObject flotillaGO)
    {
        origin = originPort;
        destination = destPort;        
        go = flotillaGO;

        go.AddComponent<NavMeshAgent>();
        agent = go.GetComponent<NavMeshAgent>();
    }
}

public class Port
{
    public Vector3 position;
    public List<Flotilla> dockedFlotillas = new List<Flotilla>();

        public Port(Vector3 newPosition)
    {
        position = newPosition;
    }
}

public class FlottillaSpawner : MonoBehaviour {
    public GameObject flottilla;
    public static int spawnSeed;
    public Transform[] portPositions;
    public Port[] ports;

    System.Random prng = new System.Random(spawnSeed);
    public float cooldown;
    private float timer;

	// Use this for initialization
	void Start () {
        ports = new Port[portPositions.Length];

        for (int i = 0; i < portPositions.Length; i++)
        {
            ports[i] = new Port(portPositions[i].position);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = cooldown;
            Debug.Log("spawn attempt");
            Spawn();
        }
	}

    void Spawn()
    {
        for (int i = 0; i < ports.Length; i++)
        {
            int nextInd = 0;// = (i < ports.Length) ? i + 1 : 0;

            if (i == ports.Length - 1)
            {
                nextInd = 0;
            }
            else
            {
                nextInd = i+1;
            }
            Debug.Log(i);
            //Debug.Log(ports.Length);
            Debug.Log(nextInd);
            if (prng.Next(0, 100) < 50)
            {
                GameObject newGo = GameObject.Instantiate(flottilla, ports[i].position, Quaternion.identity);
                Flotilla newFlotilla = new Flotilla(ports[i], ports[nextInd], newGo);
                ports[i].dockedFlotillas.Add(newFlotilla);
                Debug.Log("new flottilla");
            }
        }
    }
}
