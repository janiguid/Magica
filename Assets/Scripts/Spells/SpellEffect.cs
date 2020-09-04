using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffect
{
    public SpellEffect(float spdMod, float atkMod, float defMod, float spdModDur, float atkModDur, float defModDur)
    {
        SpeedModifier = spdMod;
        AttackModifier = atkMod;
        DefenseModifier = defMod;

        SpeedModDuration = spdModDur;
        AttackModDuration = atkModDur;
        DefenseModDuration = defModDur;
    }

    public float SpeedModifier { get; set; }

    public float AttackModifier { get; set; }

    public float DefenseModifier { get; set; }

    public float SpeedModDuration { get; set; }
    public float AttackModDuration { get; set; }
    public float DefenseModDuration { get; set; }
}
