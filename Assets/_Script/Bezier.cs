using UnityEngine;

public class Bezier : MonoBehaviour
{
    public Transform point1, point2, point3;
    private void Update()
    {
        FollowCurve();

    }
    private void FollowCurve()
    {
        transform.position= Curve(Time.time, point1.position, point2.position, point3.position);
        //Curve(time, point1.position, point2.position, point3.position);
    }

    private Vector3 Curve(float t,Vector3 p0,Vector3 p1,Vector3 p2)
    {
        //B(t) = (1-t)2P0 + 2(1-t)tP1 + t2P2
        //          u           u       tt
        //          uu * p0 + 2 * u * t * p1 + tt * p2
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }
}
