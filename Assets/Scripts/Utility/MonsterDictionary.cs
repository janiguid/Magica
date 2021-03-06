﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDictionary
{
    private Dictionary<Pair, float> MultiplierChart;

    public MonsterDictionary()
    {
        MultiplierChart = new Dictionary<Pair, float>();

        Pair GF = new Pair(Type.ElementalType.Grass, Type.ElementalType.Fire);
        MultiplierChart.Add(GF, 0.5f);

        Pair GW = new Pair(Type.ElementalType.Grass, Type.ElementalType.Water);
        MultiplierChart.Add(GW, 2f);

        Pair GG = new Pair(Type.ElementalType.Grass, Type.ElementalType.Grass);
        MultiplierChart.Add(GG, 1f);

        Pair FG = new Pair(Type.ElementalType.Fire, Type.ElementalType.Grass);
        MultiplierChart.Add(FG, 2f);

        Pair FW = new Pair(Type.ElementalType.Fire, Type.ElementalType.Water);
        MultiplierChart.Add(FW, 0.5f);

        Pair FF = new Pair(Type.ElementalType.Fire, Type.ElementalType.Fire);
        MultiplierChart.Add(FF, 1f);

        Pair WG = new Pair(Type.ElementalType.Water, Type.ElementalType.Grass);
        MultiplierChart.Add(WG, 0.5f);

        Pair WF = new Pair(Type.ElementalType.Water, Type.ElementalType.Fire);
        MultiplierChart.Add(WF, 2f);

        Pair WW = new Pair(Type.ElementalType.Water, Type.ElementalType.Water);
        MultiplierChart.Add(WW, 1f);
    }

    public float GetMultiplier(Type.ElementalType caster, Type.ElementalType target)
    {
        Pair Pairing = new Pair(caster, target);

        if (MultiplierChart.ContainsKey(Pairing))
        {
            return MultiplierChart[Pairing];
        }

        return 0f;

    }
}

struct Pair
{
    Type.ElementalType caster;
    Type.ElementalType target;

    public Pair(Type.ElementalType c, Type.ElementalType t)
    {
        caster = c;
        target = t;
    }
}
