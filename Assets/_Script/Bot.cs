/*
Bots behavior
    Generate
    Follow
    Patroll
    Death
 */

using UnityEngine;
using System.Collections;

public class Bot : MonoBehaviour
{
    #region Variables.

    public static bool left;
    public static bool isAlive = true;//Used For Flash screen
    public static float MidSpeed;
    public static float MinShare;
    public static float MaxShare;

    public float minSpeed;
    public float maxspeed;
    public bool Rotation;

    private GameObject Target;
    private GameObject topBlocker;
    private float distanceBetween;
    private float speed;
    private Rigidbody2D rbBot;
    private Transform RightCurveObject;
    private Transform LeftCurveObject;
    private Vector3 BotFinPos;
    private float Timer=0f;
    private bool RandomCheck=false;
    private int RandomNo;
    private int DirectionChange=0;
    private float OldSpeed;
    private bool BurstON=false;
    private int rno;
    private float RandomSpeed;

    private GameObject WallLeft;
    private GameObject WallRight;

    #endregion

    #region Systems Functions

    void Start()
    {
        Target = GameObject.Find("Follow");
        topBlocker = GameObject.Find("Cube_Top");
        RightCurveObject = GameObject.Find("RightCurve").GetComponent<Transform>();
        LeftCurveObject = GameObject.Find("LeftCurve").GetComponent<Transform>();
        WallLeft = GameObject.Find("WallLeft");
        WallRight = GameObject.Find("WallRight");
        distanceBetween = Random.Range(1, 6);
        speed = Random.Range(minSpeed, maxspeed);
        rbBot = GetComponent<Rigidbody2D>();
        BotFinPos = new Vector3(Random.Range(-3f,3f),Target.transform.position.y+distanceBetween,1);
        transform.position = transform.parent.position;
        MidSpeed=((minSpeed+maxspeed)/2)-1;
        MinShare = minSpeed;
        MaxShare = maxspeed;
        OldSpeed = speed;
    }

    private void FixedUpdate()
    {
        if (Rotation)
        {
            transform.Rotate(0, 0, 10);
        }

        if (!(transform.position.y <= BotFinPos.y))
        {
            if(!RandomCheck)
            {
                RandomNo =Random.Range(0, 2);
                RandomCheck = true;
            }
            else
            {
                if (RandomNo==1)
                {
                    //Left Curve
                    LeftCurve();
                    left = true;
                }
                else
                {
                    //Right Curve;
                    RightCurve();
                    left = false;
                }
            }
        }
        else
        {
            PatrollerAI();
            RandomCheck = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        left = !left;
        DirectionChange++;
        if(ScoreManager.scorePoints>=10)
        {
            if (DirectionChange > 3)
            {
                
                if(!BurstON)
                {
                    rno = Random.Range(0, 2);
                    RandomSpeed = Random.Range(1f, 3f);
                    BurstON = true;

                }
                if(DirectionChange < 5)
                {
                    
                    if (rno == 0)
                    {
                        speed += RandomSpeed; //OG CODE
                        if (speed > 8)  speed = 8;
                    }
                    else
                    {
                        speed -= RandomSpeed; //OG CODE
                        if (speed < 2)  speed = 2;
                    }
                }
                else
                {
                    DirectionChange = 0;
                }
            }
            else
            {
                //speed to normal
                speed = OldSpeed;
                BurstON = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            BotSpeedControl.BotSpeed = this.speed;
            Destroy(this.gameObject);
            BotGenerator.IsBot = false;
            isAlive = false;
            Timer = 0f;
            BotSpeedControl.AssignSpeed();
        }
    }

    #endregion


#region User Deifne Functions

    void PatrollerAI()
    {

        //if (ScoreManager.scorePoints < 2)
        //{

        //}
        //else
        //{
        //    if (!BurstON)
        //    {
        //        speed = BotSpeedControl.speed;
        //        OldSpeed = speed;
        //    }
        //}
        if (!left)
        {
            float distance = transform.position.x - WallLeft.transform.position.x;
            if (distance < 3)
            {
                if(!left)
                {
                    if (OldSpeed >= 3 && OldSpeed < 4)
                    {
                        speed -= (speed * 7) / 100;
                    }
                    else if (OldSpeed >= 4 && OldSpeed < 5)
                    {
                        speed -= (speed * 8) / 100;
                    }
                    else if (OldSpeed >= 5 && OldSpeed < 6)
                    {
                        speed -= (speed * 11) / 100;
                    }
                    else if (OldSpeed >= 6 && OldSpeed < 7)
                    {
                        speed -= (speed * 14) / 100;
                    }
                    else if (OldSpeed >= 7 && OldSpeed < 8)
                    {
                        speed -= (speed * 18) / 100;
                    }
                    else if (OldSpeed >= 8)
                    {
                        speed -= (speed * 20) / 100;
                    }
                    //speed -= (speed * 10) / 100;
                    if (speed < .5f)
                    {
                        speed = .5f;
                    }
                }
                
                rbBot.velocity = Vector2.left * speed * 100 * Time.deltaTime;
            }
            else
            {

                if (speed < OldSpeed)
                {
                    if (OldSpeed >= 3 && OldSpeed < 4)
                    {
                        speed += (speed * 7) / 100;
                    }
                    else if (OldSpeed >= 4 && OldSpeed < 5)
                    {
                        speed += (speed * 8) / 100;
                    }
                    else if (OldSpeed >= 5 && OldSpeed < 6)
                    {
                        speed += (speed * 11) / 100;
                    }
                    else if (OldSpeed >= 6 && OldSpeed < 7)
                    {
                        speed += (speed * 14) / 100;
                    }
                    else if (OldSpeed >= 7 && OldSpeed < 8)
                    {
                        speed += (speed * 18) / 100;
                    }
                    else if (OldSpeed >= 8)
                    {
                        speed += (speed * 20) / 100;
                    }
                    //speed += (speed * 10) / 100;

                    if (speed>OldSpeed)
                    {
                        speed = OldSpeed;
                    }
                }

                rbBot.velocity = Vector2.left * speed * 100 * Time.deltaTime;
            }
        }
        else
        {
            float distance = transform.position.x - WallRight.transform.position.x;

            if (distance > -3f)
            {
                if (OldSpeed >= 3 && OldSpeed < 4)
                {
                    speed -= (speed * 7) / 100;
                }
                else if (OldSpeed >= 4 && OldSpeed < 5)
                {
                    speed -= (speed * 8) / 100;
                }
                else if (OldSpeed >= 5 && OldSpeed < 6)
                {
                    speed -= (speed * 11) / 100;
                }
                else if (OldSpeed >= 6 && OldSpeed < 7)
                {
                    speed -= (speed * 14) / 100;
                }
                else if (OldSpeed >= 7 && OldSpeed < 8)
                {
                    speed -= (speed * 18) / 100;
                }
                else if (OldSpeed >= 8)
                {
                    speed -= (speed * 20) / 100;
                }

                if (speed < .5f)
                {
                    speed = .5f;
                }
                rbBot.velocity = Vector2.right * speed * 100 * Time.deltaTime;
            }
            else
            {
                if (speed < OldSpeed)
                {
                    if (OldSpeed >= 3 && OldSpeed < 4)
                    {
                        speed += (speed * 7) / 100;
                    }
                    else if (OldSpeed >= 4 && OldSpeed < 5)
                    {
                        speed += (speed * 8) / 100;
                    }
                    else if (OldSpeed >= 5 && OldSpeed < 6)
                    {
                        speed += (speed * 11) / 100;
                    }
                    else if (OldSpeed >= 6 && OldSpeed < 7)
                    {
                        speed += (speed * 14) / 100;
                    }
                    else if (OldSpeed >= 7 && OldSpeed < 8)
                    {
                        speed += (speed * 18) / 100;
                    }
                    else if (OldSpeed >= 8)
                    {
                        speed += (speed * 20) / 100;
                    }
                    //speed += (speed * 10) / 100;

                    if (speed > OldSpeed)
                    {
                        speed = OldSpeed;
                    }
                }

                rbBot.velocity = Vector2.right * speed * 100 * Time.deltaTime;
            }
        }
    }

    #region Curves
    private void RightCurve()
    {
        transform.position = Curve(Timer,transform.parent.position,RightCurveObject.position,BotFinPos);
        Timer += Time.deltaTime *2;
        Physics2D.IgnoreCollision(topBlocker.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void LeftCurve()
    {
        transform.position = Curve(Timer, transform.parent.position, LeftCurveObject.position, BotFinPos);
        Timer += Time.deltaTime * 2;
        Physics2D.IgnoreCollision(topBlocker.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private Vector3 Curve(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }
    #endregion

    #endregion

}