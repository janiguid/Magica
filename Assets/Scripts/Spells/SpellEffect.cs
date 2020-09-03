using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffect
{
    public SpellEffect(float spdMod, float atkMod, float defMod)
    {
        SpeedModifier = spdMod;
        AttackModifier = atkMod;
        DefenseModifier = defMod;
    }

    public float SpeedModifier { get; set; }

    public float AttackModifier { get; set; }

    public float DefenseModifier { get; set; }
}
