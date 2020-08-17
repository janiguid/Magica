using System.Collections;
using System.Collections.Generic;

public class SpellMixer
{
    private Dictionary<string, Type.ElementalType> spellBook;

    public SpellMixer()
    {
        spellBook = new Dictionary<string, Type.ElementalType>();
        spellBook.Add("fff", Type.ElementalType.Fire);
        spellBook.Add("www", Type.ElementalType.Water);
        spellBook.Add("ggg", Type.ElementalType.Grass);

    }

    public Type.ElementalType MixSpells(string input)
    {
        if (spellBook.ContainsKey(input) == false)
        {
            return Type.ElementalType.Neutral;
        }
        return spellBook[input];
    }

    public char GetRuneType(Type.ElementalType type)
    {
        switch (type) {
            case Type.ElementalType.Fire:
                return 'f';
            case Type.ElementalType.Grass:
                return 'g';
            case Type.ElementalType.Water:
                return 'w';
        }

        return 'n';
                
    }
}
