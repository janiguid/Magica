using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Water : SpellButton
{

    public override void InitializeElement()
    {
        //print("Successfully set to water type");
        element = Type.ElementalSpellTypes.Water;
    }



}
