using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Fire : SpellButton
{
    public override void InitializeElement()
    {
        //print("Successfully set to fire type");
        element = Type.ElementalSpellTypes.Fire;
    }



}
