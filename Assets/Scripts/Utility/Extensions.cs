using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void SetPosition(this Transform trans, Vector2 vector2)
    {
        Vector3 corrected = vector2;
        corrected.z = trans.position.z;

        trans.position = corrected;
    }
}
