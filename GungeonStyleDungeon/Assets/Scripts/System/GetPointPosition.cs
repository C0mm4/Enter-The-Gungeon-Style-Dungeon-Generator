using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Func
{
    public static PointPosition GetPointPosition(Vector2 baseP, Vector2 targetP)
    {
        float horizonDist = targetP.x - baseP.x;
        float verticalDist = targetP.y - baseP.y;

        if (Mathf.Abs(horizonDist) >= Mathf.Abs(verticalDist))
        {
            if (horizonDist > 0)
            {
                return PointPosition.Right;
            }
            else
            {
                return PointPosition.Left;
            }

        }
        else
        {
            if (verticalDist > 0)
            {
                return PointPosition.Up;
            }
            else
            {
                return PointPosition.Down;
            }
        }
    }

    public static int[] xpos = new int[4] { 0, 0, 1, -1 };
    public static int[] ypos = new int[4] { 1, -1, 0, 0 };

    public static int[] xXpos = new int[4] { -1, -1, 1, 1 };
    public static int[] yXpos = new int[4] { -1, 1, 1, -1 };
}