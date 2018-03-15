using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [HideInInspector]
    public static GameController instance = null;
    public int maxFlottillas;
    public int flottillaInGame;
    private PortController[] allPorts;
    public GameObject player;
    public AudioController audioController;

    private int Score;
    public int score
    {
        get
        {
            return Score;
        }
        set
        {
            Score = value;
            if (score == victoryScore)
            {
                Victory();
            }
            EventManager.TriggerEvent(SimpleEvent.SCORE_CHANGE);
        }
    }

    public int victoryScore;

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
        EventManager.TriggerEvent(SimpleEvent.SCENE_LOADED);
        player = GameObject.FindGameObjectWithTag("Player");
        audioController = gameObject.GetComponent<AudioController>();
        PauseGame(1); // starts by pausing the game

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

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame(-1);
        }
    }

    /// <summary>
    /// pause = 0, unpause = 1, flip = -1
    /// </summary>
    /// <param name="doPause"></param>
    void PauseGame(int doPause)
    {
        if (doPause != 0 && Mathf.Abs(doPause) != 1)
        {
            Debug.Log("Invalid Pause argument, select 0, 1, or -1.");
            return;
        }

        if (doPause == 1)
        {
            Time.timeScale = 0;
            Debug.Log("Pause");

        }
        else if (doPause == 0)
        {
            Time.timeScale = 1;
            Debug.Log("UnPause");
        }
        else
        {
            Time.timeScale = Mathf.Abs(Time.timeScale - 1);
            Debug.Log("Flip Pause");
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER.");
        player.SetActive(false);
        EventManager.TriggerEvent(SimpleEvent.GAME_OVER);
        PauseGame(1);
    }

    public void Victory()
    {
        Debug.Log("Victory.");
        player.SetActive(false);
        EventManager.TriggerEvent(SimpleEvent.VICTORY);
        PauseGame(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        StartGame();
    }

    public void StartGame()
    {
        EventManager.TriggerEvent(SimpleEvent.GAME_START);
        PauseGame(0);
    }

    public float GetNormalizeScore()
    {
        if (score != 0)
        {
            Debug.Log(victoryScore + "  .  " + score + "   .  " + victoryScore / score);
            return score / (float) victoryScore;
        }
        else
        {
            return 0;
        }
    }
}
