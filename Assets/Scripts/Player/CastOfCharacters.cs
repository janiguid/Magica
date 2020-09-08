using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastOfCharacters
{    

    public enum CharacterList
    {
        Elia,
        Calla,
        Pava,
        Mari
    }

    public Dictionary<CharacterList, CharacterData> characterDictionary;

    public CastOfCharacters()
    {
        characterDictionary = new Dictionary<CharacterList, CharacterData>();
        characterDictionary.Add(CharacterList.Elia, new CharacterData(20, 5, 5, "ffww"));
        characterDictionary.Add(CharacterList.Calla, new CharacterData(15, 15, 5, "fffwww"));
        characterDictionary.Add(CharacterList.Pava, new CharacterData(20, 5, 10, "gggwwf"));
        characterDictionary.Add(CharacterList.Mari, new CharacterData(20, 10, 5, "ffffwg"));
    }
}

public struct CharacterData
{
    public float HP;
    public float ATT;
    public float DEF;
    public string SpecialSpell;

    public CharacterData(float hp, float att, float def, string spll)
    {
        HP = hp;
        ATT = att;
        DEF = def;
        SpecialSpell = spll;
    }

}