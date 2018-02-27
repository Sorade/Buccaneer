using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [HideInInspector]
    public static UIManager instance = null;
    public Text scoreBoard;

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

    private void Update()
    {
        scoreBoard.text = GameController.instance.score.ToString();
    }
}
