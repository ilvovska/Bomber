using System.Collections.Generic;
using UnityEngine;

public static class Direction
{
    public enum Type
    {
        Hour1 = 0,
        Hour3 = 1,
        Hour5 = 2,
        Hour7 = 3,
        Hour9 = 4,
        Hour11 = 5,
    }
    
    private static readonly Dictionary<Type, Vector3> directionVectors = new Dictionary<Type, Vector3>()
    {
        { Type.Hour1, new Vector3(0.5f, 0, 0.866f) },
        { Type.Hour3, new Vector3(1, 0, 0) },
        { Type.Hour5, new Vector3(0.5f, 0, -0.866f) },
        { Type.Hour7, new Vector3(-0.5f, 0, -0.866f) },
        { Type.Hour9, new Vector3(-1, 0, 0) },
        { Type.Hour11, new Vector3(-0.5f, 0, 0.866f) },
    };

    public static Vector3 DirectionToVector3(Type direction) => directionVectors[direction];

    public static Type Vector2ToDirection(Vector2 direction)
    {
        var axis = (int)(Vector2.Angle(direction, Vector2.up) / 60);
        var right = direction.x > 0;

        switch (axis)
        {
            case 0: return right ? Type.Hour1 : Type.Hour11;
            case 1:return right ? Type.Hour3 : Type.Hour9;
            case 2:return right ?Type.Hour5 : Type.Hour7;
            default: return Type.Hour1;
        }
    }
}