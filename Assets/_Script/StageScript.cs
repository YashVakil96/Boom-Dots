using UnityEngine;

public class StageScript : MonoBehaviour
{

    #region Variables
    private float StageSpeed;
    private int StageMileStone;
    #endregion

    #region System Methods
    private void Start()
    {
        StageMileStone = 10;
        StageSpeed = 0.3f;
    }

    private void FixedUpdate()
    {
        if (ScoreManager.scorePoints > 0)
        {
            if (ScoreManager.scorePoints > StageMileStone)
            {
                StageSpeed += StageSpeed;
                StageMileStone += StageMileStone;
            }

            //transform.Translate(Vector2.up * StageSpeed * Time.deltaTime);
        }
    }
    #endregion
}
