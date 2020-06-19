using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell:MonoBehaviour
{
    Vector3 minBounds;
    Vector3 maxBounds;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private void Start()
    {
        minBounds = GetComponent<SpriteRenderer>().bounds.min;
        maxBounds = GetComponent<SpriteRenderer>().bounds.max;

        minBounds = Camera.main.WorldToScreenPoint(minBounds);
        maxBounds = Camera.main.WorldToScreenPoint(maxBounds);

        xMin = minBounds.x;
        xMax = maxBounds.x;
        yMin = minBounds.y;
        yMax = maxBounds.y;

    }

    public virtual bool Trigger(float x, float y) {
        print("Base spell triggered. No bueno");
        return false;
    }
}
