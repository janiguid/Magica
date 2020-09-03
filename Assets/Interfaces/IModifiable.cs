using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModifiable
{
    void ModifyStats(SpellEffect effect);

    void ModifySpeed(float multiplier);

    void ModifyAttack(float multiplier);

    void ModifyDefense(float multiplier);
}
