using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell:MonoBehaviour
{

    public Type.ElementalType element;

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


        InitializeElement();
    }

    public virtual void InitializeElement()
    {
        print("Set base element. No bueno");
    }

    public virtual bool Trigger(float x, float y) {
        if (xMin < x && x < xMax)
        {
            if (yMin < y && y < yMax)
            {
                GameObject.FindObjectOfType<Player>().SetElement(element);
                return true;
            }
        }

        return false;
    }
}
