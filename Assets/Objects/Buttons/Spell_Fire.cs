using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Fire : Spell
{
    public override void InitializeElement()
    {
        //print("Successfully set to fire type");
        element = Type.ElementalType.Fire;
    }



}
