﻿using UnityEngine;

public static class VectorExtensions
{

    /// <summary>
    /// Returns the vector with just the X and Z components
    /// </summary>
    public static Vector3 XZ(this Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z);
    }

    /// <summary>
    /// Returns the vector with just the Y component
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static Vector3 Y(this Vector3 vector)
    {
        return new Vector3(0, vector.y, 0);
    }

    /// <summary>
    /// Returns a vector with just the absolute value of each component
    /// </summary>
    public static Vector3 Abs(this Vector3 vector)
    {
        return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    }

    /// <summary>
    /// Returns the vector with just the Y component set
    /// </summary>
    public static Vector2 Y(this Vector2 vector)
    {
        return new Vector2(0, vector.y);
    }

    /// <summary>
    /// Returns the vector with just the Y component set
    /// </summary>
    public static Vector2 X(this Vector2 vector)
    {
        return new Vector2(vector.x, 0);
    }

    /// <summary>
    /// Returns the vector with just the Y component set with an offset
    /// </summary>
    public static Vector2 Y(this Vector2 vector, float offset)
    {
        return new Vector2(0, vector.y + offset);
    }
}