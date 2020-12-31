using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScreen : MonoBehaviour
{

    #region User Define Methods
    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
