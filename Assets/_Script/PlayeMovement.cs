using UnityEngine;
using System.Collections;

public class PlayeMovement : MonoBehaviour
{
    #region Variables

    public float speed=20;
    public bool Rotation;
    public GameObject Borders;
    public GameObject Particles;
    public GameObject DeadMenu;

    private Rigidbody2D rb;
    private Vector3 origin;
    private Vector3 originBorder;
    private DeathFlash flash;
    private ScreenManager screenManager;
    private float StageSpeed;

    #endregion

    #region System Methods

    private void Start()
    {
        rb= this.GetComponent<Rigidbody2D>();
        origin=transform.position;
        originBorder = Borders.transform.position;
        flash =FindObjectOfType<DeathFlash>();
        screenManager = FindObjectOfType<ScreenManager>();
    }

    void Update()
    {
        bool Pause=ScreenManager.isPaused;
        bool Resume=ScreenManager.isResume;

        if (GameControl.isGameRunning)
        {
            if (Rotation)
            {
                transform.Rotate(0, 0, 10);
            }
            if (Input.touchCount>0 || Input.GetMouseButtonDown(0))
            {
                if(Pause)
                {
                    Debug.Log("Paused INSIDE");
                    return;
                }

                if(Resume)
                {
                    ScreenManager.isResume= false;
                    return;
                }

                else
                {
                    if((Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Ended) || Input.GetMouseButtonDown(0))
                    {
                        MovePlayer();
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Blocker"))
        {
            flash.Flash();
            rb.velocity=new Vector2(0f,0f);
            Instantiate(Particles,transform.position,Quaternion.identity);
            gameObject.SetActive(false);
            screenManager.deathScreen();
            Invoke("disableFlashImage",.2f);
            ScoreManager.scorePoints = 0;
        }

        if (collision.gameObject.tag.Equals("Bot"))
        {
            
            //Debug.Log(collision.gameObject.transform.GetChild(0).name);   //Getting Child name
            Instantiate(Particles, transform.position, Quaternion.identity);
            rb.velocity = new Vector2(0f, 0f);
            StartCoroutine(Delay());
            Borders.transform.position = originBorder;
            if (!Accurate.PerfectHit)
            {
                ScoreManager.scorePoints++;
            }
            else
            {
                Accurate.PerfectHit = false;
            }
            Debug.Log(ScoreManager.scorePoints);
        }
    }

    #endregion

    #region User Defined Methods

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.2F);
        transform.position = origin;
    }

    void disableFlashImage()
    {
            DeathFlash.flashImage.enabled=false;
    }

    void MovePlayer()
    {
        rb.velocity = Vector2.up * speed;
    }

    #endregion
}