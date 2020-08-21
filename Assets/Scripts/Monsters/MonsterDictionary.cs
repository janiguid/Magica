using System.Collections;
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


        //Pure Monsters
        Pair WPF = new Pair(Type.ElementalType.Water, Type.ElementalType.PureFire);
        MultiplierChart.Add(WPF, 2);

        Pair GPW = new Pair(Type.ElementalType.Grass, Type.ElementalType.PureWater);
        MultiplierChart.Add(GPW, 2);

        Pair FPG = new Pair(Type.ElementalType.Fire, Type.ElementalType.PureGrass);
        MultiplierChart.Add(FPG, 2);

        //Fire-Grass Monster
        Pair FireGrassMonster = new Pair(Type.ElementalType.FFW, Type.ElementalType.GGF);
        MultiplierChart.Add(FireGrassMonster, 2);

        //Grass-Water Monster
        Pair GrassWaterMonster = new Pair(Type.ElementalType.FFG, Type.ElementalType.GGW);
        MultiplierChart.Add(GrassWaterMonster, 2);

        //Water-Fire Monster
        Pair WaterFireMonster = new Pair(Type.ElementalType.GGW, Type.ElementalType.WWF);
        MultiplierChart.Add(WaterFireMonster, 2);

    }


    public float GetMultiplier(Type.ElementalType spellType, Type.ElementalType monsterType)
    {
        Pair Pairing = new Pair(spellType, monsterType);

        if (MultiplierChart.ContainsKey(Pairing))
        {
            return MultiplierChart[Pairing];
        }

        return 0f;

    }
}

struct Pair
{
    Type.ElementalType spellType;
    Type.ElementalType monsterType;

    public Pair(Type.ElementalType typeOfSpell, Type.ElementalType typeOfMonster)
    {
        spellType = typeOfSpell;
        monsterType = typeOfMonster;
    }
}
