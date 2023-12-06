using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        // Distance formula: distance = sqrt((x2 - x1)^2 + (y2 - y1)^2)
        float distance = Mathf.Sqrt(Mathf.Pow(p2.x - p1.x, 2) + Mathf.Pow(p2.y - p1.y, 2));
        return distance;
    }

    public static void CalculateDistance()
    {
        HVector2D a = new HVector2D(8f, 5f);
        HVector2D b = new HVector2D(1f, 3f);
        float distance = FindDistance(a, b);

        Debug.Log("Distance between points a and b: " + distance);
    }
}



