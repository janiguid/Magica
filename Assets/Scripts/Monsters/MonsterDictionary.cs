using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDictionary
{
    private Dictionary<Pair, float> MultiplierChart;

    public MonsterDictionary()
    {
        MultiplierChart = new Dictionary<Pair, float>();

        Pair GF = new Pair(Type.ElementalSpellTypes.Grass, Type.MonsterTypes.Fire);
        MultiplierChart.Add(GF, 0.5f);

        Pair GW = new Pair(Type.ElementalSpellTypes.Grass, Type.MonsterTypes.Water);
        MultiplierChart.Add(GW, 2f);

        Pair GG = new Pair(Type.ElementalSpellTypes.Grass, Type.MonsterTypes.Grass);
        MultiplierChart.Add(GG, 1f);

        Pair FG = new Pair(Type.ElementalSpellTypes.Fire, Type.MonsterTypes.Grass);
        MultiplierChart.Add(FG, 2f);

        Pair FW = new Pair(Type.ElementalSpellTypes.Fire, Type.MonsterTypes.Water);
        MultiplierChart.Add(FW, 0.5f);

        Pair FF = new Pair(Type.ElementalSpellTypes.Fire, Type.MonsterTypes.Fire);
        MultiplierChart.Add(FF, 1f);

        Pair WG = new Pair(Type.ElementalSpellTypes.Water, Type.MonsterTypes.Grass);
        MultiplierChart.Add(WG, 0.5f);

        Pair WF = new Pair(Type.ElementalSpellTypes.Water, Type.MonsterTypes.Fire);
        MultiplierChart.Add(WF, 2f);

        Pair WW = new Pair(Type.ElementalSpellTypes.Water, Type.MonsterTypes.Water);
        MultiplierChart.Add(WW, 1f);


        //Pure Monsters
        Pair WPF = new Pair(Type.ElementalSpellTypes.Water, Type.MonsterTypes.PureFire);
        MultiplierChart.Add(WPF, 2);

        Pair GPW = new Pair(Type.ElementalSpellTypes.Grass, Type.MonsterTypes.PureWater);
        MultiplierChart.Add(GPW, 2);

        Pair FPG = new Pair(Type.ElementalSpellTypes.Fire, Type.MonsterTypes.PureGrass);
        MultiplierChart.Add(FPG, 2);

        //Fire-Grass Monster
        Pair FireGrassMonster = new Pair(Type.ElementalSpellTypes.FFW, Type.MonsterTypes.GGF);
        MultiplierChart.Add(FireGrassMonster, 2);

        //Grass-Water Monster
        Pair GrassWaterMonster = new Pair(Type.ElementalSpellTypes.FFG, Type.MonsterTypes.GGW);
        MultiplierChart.Add(GrassWaterMonster, 2);

        //Water-Fire Monster
        Pair WaterFireMonster = new Pair(Type.ElementalSpellTypes.GGW, Type.MonsterTypes.WWF);
        MultiplierChart.Add(WaterFireMonster, 2);

    }


    public float GetMultiplier(Type.ElementalSpellTypes spellType, Type.MonsterTypes monsterType)
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
    Type.ElementalSpellTypes spellType;
    Type.MonsterTypes monsterType;

    public Pair(Type.ElementalSpellTypes typeOfSpell, Type.MonsterTypes typeOfMonster)
    {
        spellType = typeOfSpell;
        monsterType = typeOfMonster;
    }
}
