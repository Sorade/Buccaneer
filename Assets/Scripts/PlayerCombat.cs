using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public bool EvaluateOutcome (FlottillaStats enemyStats) {
        return false;
	}

    public bool ResolveOutcome(FlottillaStats enemyStats)
    {
        return true;
    }
}
