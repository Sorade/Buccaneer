using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [HideInInspector]
    public static UIManager instance = null;
    public Text scoreBoard;

    [Header("Main Menu UI")]
    public GameObject mainMenu;

    [Header("Game Over UI")]
    public GameObject gameOverMenu;

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

    }

    private void OnDisable()
    {
        EventManager.StopListening(SimpleEvent.GAME_OVER, ShowGameOverMenu);
        EventManager.StopListening(SimpleEvent.SCENE_LOADED, ShowMainMenu);
        EventManager.StopListening(SimpleEvent.GAME_START, HideMainMenu);

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
}
