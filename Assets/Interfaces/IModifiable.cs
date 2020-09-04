using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModifiable
{
    void ModifyStats(SpellEffect effect);

    void ModifySpeed(float multiplier, float duration);

    void ModifyAttack(float multiplier, float duration);

    void ModifyDefense(float multiplier, float duration);
}
