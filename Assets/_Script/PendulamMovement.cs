using UnityEngine;

public class PendulamMovement : MonoBehaviour
{

    #region Variable

    public float speed;

    private float Oldspeed;
    private float ScreenWidth;
    private float ScreenHeight;
    private float ObjectWidth;
    private float ObjectHeight;
    private bool left=true;
    private Rigidbody2D rbBot;

    #endregion

    #region System Methods

    private void Start()
    {
        rbBot = GetComponent<Rigidbody2D>();
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        ScreenWidth = stageDimensions.x;
        ScreenHeight = stageDimensions.y;

        ObjectWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        ObjectHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        Oldspeed = speed;

    }

    private void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        left = !left;
    }

    #endregion

    #region User Define Method

    void Movement()
    {
        if (left)
        {
            float distance = transform.position.x - ScreenWidth;
            if (distance >-1.5)
            {
                speed -= Time.deltaTime * 1.5f;
                rbBot.velocity = Vector2.right * speed * 100 * Time.deltaTime;
            }
            else
            {
                if(speed < Oldspeed)
                {
                    speed += Time.deltaTime * 1.5f;
                }
                rbBot.velocity = Vector2.right * speed * 100 * Time.deltaTime;
            }

        }
        else
        {
            float distance = transform.position.x - (-ScreenWidth);
            if (distance < 1.5)
            {
                speed -= Time.deltaTime * 1.5f;
                rbBot.velocity = Vector2.left * speed * 100 * Time.deltaTime;
            }
            else
            {
                if (speed < Oldspeed)
                {
                    speed += Time.deltaTime * 1.5f;
                }
                rbBot.velocity = Vector2.left * speed * 100 * Time.deltaTime;
            }
        }
    }

    #endregion
}
