using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_LevelConfig : ScriptableObject
{
    [SerializeField] private int totalMonsterCount;
    [SerializeField] private int fireMonstersCount;
    [SerializeField] private int waterMonstersCount;
    [SerializeField] private int grassMonstersCount;

    public int TotalMonsterCount
    {
        get
        {
            return totalMonsterCount;
        }
        set
        {
            totalMonsterCount = value;
        }
    }

    public int FireMonsterCount
    {
        get
        {
            return fireMonstersCount;
        }
        set
        {
            fireMonstersCount = value;
        }
    }

    public int WaterMonsterCount
    {
        get
        {
            return waterMonstersCount;
        }
        set
        {
            waterMonstersCount = value;
        }
    }

    public int GrassMonsterCount
    {
        get
        {
            return grassMonstersCount;
        }
        set
        {
            grassMonstersCount = value;
        }
    }
}
