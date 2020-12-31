using UnityEngine;

public class BotGenerator : MonoBehaviour
{
    #region Variables

    public GameObject Bot;

    public static bool IsBot;

    #endregion

    #region System Methods

    private void Start()
    {
        IsBot = false;
    }
    void Update()
    {
        if (GameControl.isGameStarted)
        {
            if (!IsBot)
            {
                Instantiate(Bot, transform.parent);
                IsBot = true;
            }
        }

        else return;
    }

    #endregion
}
