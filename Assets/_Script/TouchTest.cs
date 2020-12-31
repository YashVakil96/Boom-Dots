using UnityEngine;

public class TouchTest : MonoBehaviour
{
    public static bool GameResume;
    private void Update()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Ended)
        {
            Debug.Log("RESUME CLICKED");
            GameResume = true;
        }
    }

    
}
