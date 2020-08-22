using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maximums
{
    private static int MAXIMUM_NUMBER_OF_MONSTER_TYPES = 9;

    public static int GetMaxMonsterTypes()
    {
        MAXIMUM_NUMBER_OF_MONSTER_TYPES = System.Enum.GetNames(typeof(Type.ElementalSpellTypes)).Length;
        MAXIMUM_NUMBER_OF_MONSTER_TYPES -= 1;
        return MAXIMUM_NUMBER_OF_MONSTER_TYPES;
    }
}
