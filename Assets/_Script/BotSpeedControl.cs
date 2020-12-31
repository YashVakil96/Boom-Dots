using UnityEngine;

public class BotSpeedControl : MonoBehaviour
{
    #region Variable

    public static float BotSpeed;
    public static float[] BotSpeeds;
    public static float speed;

    #endregion

    #region System Methods

    private void Start()
    {
        BotSpeeds = new float[2];
    }

    #endregion

    #region User Defined Methods

    public static void AssignSpeed()
    {
        if(BotSpeeds[0]==0)
        {
            BotSpeeds[0] = BotSpeed;
        }

        
        if(BotSpeeds[1] == 0 && BotSpeeds[0]!=0)
        {
            BotSpeeds[1] = BotSpeed;
        }

        else
        {
            BotSpeeds[0] = BotSpeeds[1];
            BotSpeeds[1] = BotSpeed;
        }

        SpeedCheck();
    }


    public static void SpeedCheck()
    {
        if(BotSpeeds[0] < Bot.MidSpeed && BotSpeeds[1] < Bot.MidSpeed)
        {
            //Debug.Log("Third Bot FAST");
            speed = Random.Range(Bot.MidSpeed, Bot.MaxShare);
            if(speed>8)
            {
                speed = 8;
            }
        }

        if (BotSpeeds[0] > Bot.MidSpeed && BotSpeeds[1] > Bot.MidSpeed)
        {
            //Debug.Log("Third Bot SLOW");
            speed = Random.Range(Bot.MinShare,Bot.MidSpeed);
            if(speed<Bot.MinShare)
            {
                speed = Bot.MinShare;
            }
        }
    }

    #endregion
}
