using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [HideInInspector]
    public static UIManager instance = null;
    public Text scoreBoard;
    public Slider reputationSlider;

    [Header("Main Menu UI")]
    public GameObject mainMenu;

    [Header("Game Over UI")]
    public GameObject gameOverMenu;

    [Header("Victory UI")]
    public GameObject victoryMenu;    

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

    private void OnEnable()
    {
        EventManager.StartListening(SimpleEvent.GAME_OVER, ShowGameOverMenu);
        EventManager.StartListening(SimpleEvent.SCENE_LOADED, ShowMainMenu);
        EventManager.StartListening(SimpleEvent.GAME_START, HideMainMenu);
        EventManager.StartListening(SimpleEvent.SCORE_CHANGE, UpdateReputation);
        EventManager.StartListening(SimpleEvent.VICTORY, ShowVictoryMenu);
    }

    private void OnDisable()
    {
        EventManager.StopListening(SimpleEvent.GAME_OVER, ShowGameOverMenu);
        EventManager.StopListening(SimpleEvent.SCENE_LOADED, ShowMainMenu);
        EventManager.StopListening(SimpleEvent.GAME_START, HideMainMenu);
        EventManager.StopListening(SimpleEvent.SCORE_CHANGE, UpdateReputation);
        EventManager.StopListening(SimpleEvent.VICTORY, ShowVictoryMenu);
    }

    private void Update()
    {
        scoreBoard.text = GameController.instance.score.ToString();
    }

    void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
    }

    void HideMainMenu()
    {
        mainMenu.SetActive(false);
    }

    void UpdateReputation()
    {
        reputationSlider.value = GameController.instance.GetNormalizeScore();
    }

    void ShowVictoryMenu()
    {
        victoryMenu.SetActive(true);
    }
}
