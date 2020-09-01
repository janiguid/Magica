using System.Collections;
using System.Collections.Generic;

public class SpellMixer
{
    private Dictionary<string, Type.ElementalSpellTypes> spellBook;


    public SpellMixer()
    {
        spellBook = new Dictionary<string, Type.ElementalSpellTypes>();
        spellBook.Add("fff", Type.ElementalSpellTypes.Fire);
        spellBook.Add("www", Type.ElementalSpellTypes.Water);
        spellBook.Add("ggg", Type.ElementalSpellTypes.Grass);
        spellBook.Add("ffw", Type.ElementalSpellTypes.FFW);
        spellBook.Add("ggw", Type.ElementalSpellTypes.GGW);
        spellBook.Add("ffg", Type.ElementalSpellTypes.FFG);

    }

    public Type.ElementalSpellTypes MixSpells(string input)
    {

        string corrected = new string(AlphabetizeRunes(input.ToCharArray()));


        if (spellBook.ContainsKey(corrected) == false)
        {
            
            return Type.ElementalSpellTypes.Neutral;
        }
        return spellBook[corrected];
    }

    char[] AlphabetizeRunes(char[] runes)
    {
        for (int i = 0; i < runes.Length; ++i)
        {
            for(int j = i; j < runes.Length; ++j)
            {
                if((int)runes[i] > (int)runes[j])
                {
                    char temp = runes[i];
                    runes[i] = runes[j];
                    runes[j] = temp;
                }
            }
        }
        return runes;
    }

    public char GetRuneType(Type.ElementalSpellTypes type)
    {
        switch (type) {
            case Type.ElementalSpellTypes.Fire:
                return 'f';
            case Type.ElementalSpellTypes.Grass:
                return 'g';
            case Type.ElementalSpellTypes.Water:
                return 'w';
        }

        return 'n';
                
    }
}
