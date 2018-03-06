using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [HideInInspector]
    public static UIManager instance = null;
    public Text scoreBoard;
    public GameObject restartButton;
    public GameObject gameOverText;

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

    private void Start()
    {
        EventManager.StartListening(SimpleEvent.GAME_OVER, ShowGameOverMenu);
    }

    private void Update()
    {
        scoreBoard.text = GameController.instance.score.ToString();
    }

    void ShowGameOverMenu()
    {
        restartButton.SetActive(true);
        gameOverText.SetActive(true);
    }
}
