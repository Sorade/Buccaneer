using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlottillaPool : MonoBehaviour {
    public GameObject prefab;
    public FlottillaBlueprint[] bp;

    [HideInInspector]
    public Queue<FlottillaController> pool;

	// Use this for initialization
	void Start () {
        pool = new Queue<FlottillaController>();
	}
	
	public void Pool (FlottillaController toPool) {
        pool.Enqueue(toPool);
	}

    public FlottillaController UnPool()
    {
        if (pool.Count > 0)
        {
            FlottillaController f = pool.Dequeue();
            return f;
        }
        else
        {
            GameObject newFlottilla = GameObject.Instantiate(prefab);
            FlottillaController controller = newFlottilla.GetComponent<FlottillaController>();
            return controller;
        }
    }
}
