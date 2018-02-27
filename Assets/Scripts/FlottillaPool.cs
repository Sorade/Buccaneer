using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlottillaPool : MonoBehaviour {
    public GameObject prefab;
    public FlottillaBlueprint[] bp;

    [HideInInspector]
    public Queue<FlottillaController> pool;

    void Start () {
        pool = new Queue<FlottillaController>();
	}
	
	public void Pool (FlottillaController toPool) {
        toPool.gameObject.SetActive(false);
        pool.Enqueue(toPool);
	}

    public FlottillaController UnPool()
    {
        if (pool.Count > 0)
        {
            FlottillaController fc = pool.Dequeue();
            fc.SetUp();
            fc.gameObject.SetActive(true);
            return fc;
        }
        else
        {
            GameObject newFlottilla = GameObject.Instantiate(prefab);
            FlottillaController controller = newFlottilla.GetComponent<FlottillaController>();
            return controller;
        }
    }
}
