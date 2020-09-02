using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffect
{
    float speedModifier;
    float damageModifier;
    float defenseModifier;

    public SpellEffect(float spdMod, float dmgMod, float defMod)
    {
        speedModifier = spdMod;
        damageModifier = dmgMod;
        defenseModifier = defMod;
    }
}
