using UnityEngine;
using System.Collections;

public class Accurate : MonoBehaviour
{
    #region Variables

    public static bool PerfectHit=false;

    #endregion

    #region System Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="Player")
        {
            int no = Random.Range(0, 3);
            //Works for perfect hit
            //increase Score by some points
            if(no==2)
            {
                ScoreManager.scorePoints += 5;
                PerfectHit = true;
            }
        }
        
    }

    #endregion
}
