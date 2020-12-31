/*
                STATISTICS

    Today		All Time 		7 Days

        Games played
        Best Score
        Average Score
        Perfect Hits
        Perfect Hits per Game
        Highest Perfect Hit Chain

 */

using UnityEngine;

public class Statistics : MonoBehaviour
{
    #region Variable
    // Games Played
    private int Today_GamesPlayed;
    private int ALlTime_GamesPlayed;
    private int Days7_GamesPlayed;

    // Best Score
    private int Today_BestScore;
    private int ALlTime_BestScore;
    private int Days7_BestScore;

    //Average Score
    private int Today_AverageScore;
    private int ALlTime_AverageScore;
    private int Days7_AverageScore;

    #endregion



    #region System Methods
    private void Start()
    {
        ALlTime_GamesPlayed++;
        Today_GamesPlayed++;
        Debug.Log(ALlTime_GamesPlayed);
        Debug.Log(Today_GamesPlayed);
    }

    #endregion



    #region User Define Methods



    #endregion
}
