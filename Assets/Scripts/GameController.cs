using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [HideInInspector]
    public static GameController instance = null;
    public int maxFlottillas;
    public int flottillaInGame;
    private PortController[] allPorts;

    public int score;

    private void Awake()
    {
        #region
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        #endregion //Singleton
    }

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    public void GameOver()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
    }       
}
