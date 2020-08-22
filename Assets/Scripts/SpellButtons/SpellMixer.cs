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
        if (spellBook.ContainsKey(input) == false)
        {
            
            return Type.ElementalSpellTypes.Neutral;
        }
        return spellBook[input];
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
