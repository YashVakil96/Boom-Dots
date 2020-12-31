using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    #region Variables

    public static int scorePoints=0;

    public TMP_Text scoreText;

    private int HighScore;
    #endregion

    #region System Methods

    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log("HighScore: " + HighScore);
    }

    void Update()
    {
        scoreText.text = scorePoints.ToString("0");
        CheckHighScore();
    }

    #endregion

    #region User Define Methods
    void CheckHighScore()
    {
        if(scorePoints>HighScore)
        {
            HighScore = scorePoints;
            PlayerPrefs.SetInt("HighScore", HighScore);
            Debug.Log(HighScore);
        }
    }
    #endregion
}
