using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Grass : Spell
{

    public override void InitializeElement()
    {
        print("Successfully set to grass type");
        element = Type.ElementalType.Grass;
    }


}
