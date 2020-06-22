using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Grass : Spell
{

    public override void SetElement()
    {
        print("Successfully set to grass type");
        element = Type.ElementalType.Grass;
    }

    public override bool Trigger(float x, float y)
    {
        if(xMin < x && x < xMax)
        {
            if(yMin < y && y < yMax)
            {
                print(element);
                return true;
            }
        }

        return false;   
    }

}
