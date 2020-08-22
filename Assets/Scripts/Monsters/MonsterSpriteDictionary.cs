using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpriteDictionary
{
    private Dictionary<Type.MonsterTypes, Sprite> spriteDictionary;

    public MonsterSpriteDictionary()
    {
        spriteDictionary = new Dictionary<Type.MonsterTypes, Sprite>();
        spriteDictionary.Add(Type.MonsterTypes.Fire, Resources.Load<Sprite>("Monsters/IMG_FFF"));

        spriteDictionary.Add(Type.MonsterTypes.Water, Resources.Load<Sprite>("Monsters/IMG_WWW"));

        spriteDictionary.Add(Type.MonsterTypes.Grass, Resources.Load<Sprite>("Monsters/IMG_GGG"));

        spriteDictionary.Add(Type.MonsterTypes.PureFire, Resources.Load<Sprite>("Monsters/IMG_PF"));

        spriteDictionary.Add(Type.MonsterTypes.PureGrass, Resources.Load<Sprite>("Monsters/IMG_PG"));

        spriteDictionary.Add(Type.MonsterTypes.PureWater, Resources.Load<Sprite>("Monsters/IMG_PW"));

        spriteDictionary.Add(Type.MonsterTypes.GGF, Resources.Load<Sprite>("Monsters/IMG_GGF"));

        spriteDictionary.Add(Type.MonsterTypes.GGW, Resources.Load<Sprite>("Monsters/IMG_GGW"));

        spriteDictionary.Add(Type.MonsterTypes.WWF, Resources.Load<Sprite>("Monsters/IMG_WWF"));

    }

    public Sprite GetMonsterSprite(Type.MonsterTypes type)
    {
        if (spriteDictionary.ContainsKey(type))
        {
            return spriteDictionary[type];
        }
        else
        {

            return spriteDictionary[Type.MonsterTypes.Water];
        }
    }
}
