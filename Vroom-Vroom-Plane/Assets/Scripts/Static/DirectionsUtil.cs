using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionsUtil
{
    public enum Direction
    {
        Forward, ForwardRight, Right, BackwardsRight, Backwards, BackwardsLeft, Left, ForwardLeft
    }

    public static float DirectionToRotation(Direction direction)
    {
        return 45 * (int)direction;
    }
}
