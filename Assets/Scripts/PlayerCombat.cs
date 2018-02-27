using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    private FlottillaStats stats;
    private FlottillaStats enemyStats;
    private bool isVictorious;
    // Use this for initialization
    void Start () {
        stats = GetComponent<FlottillaStats>();
	}
	
	public bool EvaluateOutcome () {
        if (enemyStats.cannons < stats.cannons)
        {
            return true;
        }
        return false;
	}

    public bool ResolveOutcome(FlottillaStats enemy)
    {
        enemyStats = enemy;
        if (EvaluateOutcome())
        {
            Debug.Log("Player destroyed "+enemy.gameObject.name+ "and plundered "+enemy.gold+" ducats.");
            GameController.instance.score += enemy.gold;
            isVictorious = true;
            //the destruction of the flottila is handled by its own controller
        }
        else
        {           
            Debug.Log("GAME OVER.");
            GameController.instance.GameOver();
            isVictorious = false;
        }
        enemyStats = null;
        if (isVictorious)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
