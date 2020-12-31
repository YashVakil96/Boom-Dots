using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScreenManager : MonoBehaviour
{
    #region Variables

    public GameObject deadScreenUI;
    public GameObject pauseScreenUI;
    public GameObject gameScore;
    public TMP_Text deadScore;

    public static bool isPaused=false;
    public static bool isResume=true;

    #endregion


    #region User Define Functions

    public void deathScreen()
    {
        deadScreenUI.SetActive(true);
        deadScore.text = gameScore.GetComponent<TMP_Text>().text;
        gameScore.SetActive(false);
        GameControl.isGameRunning = false;
    }

    public void pauseGame()
    {
        isPaused = true;
        isResume = false;
        Time.timeScale = 0f;
        pauseScreenUI.SetActive(true);
        gameScore.SetActive(false);
        Debug.Log("Paused");
    }

    public void resumeGame()
    {
        pauseScreenUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        isResume = true;
        gameScore.SetActive(true);
        TouchTest.GameResume = false;
        Debug.Log("Resume");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }
    #endregion
}
