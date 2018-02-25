using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortController : MonoBehaviour {
    private GameController gc;
    public DockingQueue docked = new DockingQueue();
    private Vector3[] otherPortLocs;

    private float cooldown = 3f;
    private float timer;

    public class DockingQueue
    {
        private Queue<FlottillaController> queue = new Queue<FlottillaController>();
        private FlottillaController active;

        public void Enqueue(FlottillaController item)
        {
            queue.Enqueue(item);
            item.Sleep();
        }

        public FlottillaController Dequeue()
        {
            Debug.Log(queue.Count);
            active = queue.Dequeue();
            active.WakeUp();
            return active;
        }

        public int GetCount()
        {
            return queue.Count;
        }
    }

    private void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
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

    private void Update()
    {
        if (TickTimer() && docked.GetCount() > 0)
        {
            UnDock();
        }
    }

    bool TickTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = cooldown;
            return true;
        }
        return false;
    }

    public void SpawnFlottilla()
    {
        FlottillaController newFc = GameObject.FindGameObjectWithTag("GameController").GetComponent<FlottillaPool>().UnPool();
        if (newFc != null)
        {
            gc.flottillaInGame += 1;
            newFc.transform.position = transform.position;
            //newFc.ArriveInPort(this); not needed since the placement of the flottilla on the port will trigger the collision
            // causing the flottilla to dock normally
        }
    }

    public bool Dock(FlottillaController flottilla)
    {
        docked.Enqueue(flottilla);
        flottilla.Sleep();
        return true;
    }

    void UnDock()
    {
        Debug.Log(docked.GetCount());
        FlottillaController fc = docked.Dequeue();
        if (fc != null)
        {
            fc.WakeUp();
            fc.LeavePort();
        }
    }
}
