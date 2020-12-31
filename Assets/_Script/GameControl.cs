/*

 * Game Running
 * Paused or not

  */

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameControl : MonoBehaviour
{
    #region Variables.

    private ScreenManager screenManager;

    public static bool isGameStarted = false;
    public static bool isGameRunning;


    #endregion

    #region System Methods.

    private void Start()
    {
        screenManager = FindObjectOfType<ScreenManager>();
        isGameStarted = true;
        isGameRunning = true;
        Time.timeScale = 1f;
    }

    #endregion


    #region User Defined Methods.
    
    public void OnGameRestart()
    {

        ScreenManager.isPaused = false;
        ScoreManager.scorePoints = 0;
        BotGenerator.IsBot = false;
        SceneManager.LoadScene("Main Game");
    }
    #endregion
}
