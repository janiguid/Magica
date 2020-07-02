using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spell
{
    private Targeter TargetLocator;
    public GameObject Spell;
    public GameObject Blast;
    public Projectile MyProjectile;

    private void Awake()
    {
        TargetLocator = GameObject.FindObjectOfType<Targeter>();
        Blast = Instantiate(Spell);
        MyProjectile = Blast.GetComponent<Projectile>();
        MyProjectile.ResetPosition();
    }


    public override void InitializeElement()
    {
        

        //print("Successfully set to neutral");
        element = Type.ElementalType.Neutral;
    }

    public void SetElement(Type.ElementalType elem)
    {
        element = elem;
        print("New element is: " + element);
    }

    public override bool Trigger(float x, float y)
    {
        if (xMin < x && x < xMax)
        {
            if (yMin < y && y < yMax)
            {
                print("Pressed player button");
                MyProjectile.Activate(TargetLocator.GetClosestMonster().transform.position, element);
                gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                return true;
            }
        }

        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        return false;
    }
}
