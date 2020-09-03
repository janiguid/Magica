using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISusceptible
{
    void ApplySlow(float speedMod, float duration);
    void ApplyDOT(float damage, float duration);
}
