using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spell
{
    private Targeter TargetLocator;
    public GameObject Spell;
    public GameObject Blast;

    private void Awake()
    {
        TargetLocator = GameObject.FindObjectOfType<Targeter>();
        Blast = Instantiate(Spell);
        Blast.GetComponent<Projectile>().ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void InitializeElement()
    {
        print("Successfully set to neutral");
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
                print("Hit player");
                Blast.GetComponent<Projectile>().Activate(TargetLocator.GetClosestMonster().transform.position, element);
                return true;
            }
        }
        return false;
    }
}
