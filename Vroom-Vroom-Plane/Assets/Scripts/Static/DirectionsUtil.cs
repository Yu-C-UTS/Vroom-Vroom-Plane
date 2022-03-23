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
        return -45 * (int)direction;
    }

    public static Direction RotationToDirection(float rotation)
    {
        return (Direction)((Mathf.RoundToInt(rotation / -45) + 8) % 8);
    }

    public static Vector2 DirectionToVector2(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                return Vector2.up;

            case Direction.ForwardRight:
                return (Vector2.up + Vector2.right).normalized;

            case Direction.Right:
                return Vector2.right;

            case Direction.BackwardsRight:
                return (Vector2.down + Vector2.right).normalized;

            case Direction.Backwards:
                return Vector2.down;

            case Direction.BackwardsLeft:
                return (Vector2.down + Vector2.left).normalized;

            case Direction.Left:
                return Vector2.left;

            case Direction.ForwardLeft:
                return (Vector2.up + Vector2.left).normalized; 
            
            default:
            throw new System.Exception("Unrecognized Direction: " + direction.ToString());
        }
    }

    public static Direction Vector2ToDirection(Vector2 inV2)
    {
        inV2.Normalize();

        float angle = (Vector2.SignedAngle(Vector2.up, inV2) * -1 + 360);

        return (Direction)(Mathf.RoundToInt(angle / 45) % 8);
    }

    public static Vector3 V2toV3YZSwap(Vector2 v2)
    {
        return new Vector3(v2.x, 0, v2.y);
    }
}
