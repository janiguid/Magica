using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpriteDictionary
{
    private Dictionary<Type.ElementalType, Sprite> spriteDictionary;

    public MonsterSpriteDictionary()
    {
        spriteDictionary = new Dictionary<Type.ElementalType, Sprite>();
        spriteDictionary.Add(Type.ElementalType.Fire, Resources.Load<Sprite>("Monsters/IMG_FFF"));

        spriteDictionary.Add(Type.ElementalType.Water, Resources.Load<Sprite>("Monsters/IMG_WWW"));

        spriteDictionary.Add(Type.ElementalType.Grass, Resources.Load<Sprite>("Monsters/IMG_GGG"));

        spriteDictionary.Add(Type.ElementalType.PureFire, Resources.Load<Sprite>("Monsters/IMG_PF"));

        spriteDictionary.Add(Type.ElementalType.PureGrass, Resources.Load<Sprite>("Monsters/IMG_PG"));

        spriteDictionary.Add(Type.ElementalType.PureWater, Resources.Load<Sprite>("Monsters/IMG_PW"));

        spriteDictionary.Add(Type.ElementalType.GGF, Resources.Load<Sprite>("Monsters/IMG_GGF"));

        spriteDictionary.Add(Type.ElementalType.GGW, Resources.Load<Sprite>("Monsters/IMG_GGW"));

        spriteDictionary.Add(Type.ElementalType.WWF, Resources.Load<Sprite>("Monsters/IMG_WWF"));

    }

    public Sprite GetMonsterSprite(Type.ElementalType type)
    {
        if (spriteDictionary.ContainsKey(type))
        {
            return spriteDictionary[type];
        }
        else
        {
            return spriteDictionary[Type.ElementalType.Water];
        }
    }
}
