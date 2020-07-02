using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell:MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Type.ElementalType element;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;


    Vector3 minBounds;
    Vector3 maxBounds;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        minBounds = spriteRenderer.bounds.min;
        maxBounds = spriteRenderer.bounds.max;

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
                spriteRenderer.color = Color.black;
                return true;
            }
        }

        spriteRenderer.color = Color.white;
        return false;
    }
}
