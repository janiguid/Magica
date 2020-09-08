using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButtons : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite characterImage;
    [SerializeField] private string charDescripttion;

    [SerializeField] private CastOfCharacters.CharacterList characterType;



    private CastOfCharacters characterDict;
    SpriteRenderer mySpriteRenderer;
    Bounds bounds;
    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (mySpriteRenderer == null) gameObject.AddComponent<SpriteRenderer>();

        characterDict = new CastOfCharacters();

        characterImage = mySpriteRenderer.sprite;
        bounds = mySpriteRenderer.bounds;
    }

    public bool Interact(float posX, float posY)
    {

        if (posX < bounds.max.x && posX > bounds.min.x)
        {
            if (posY < bounds.max.y && posY > bounds.min.y)
            {
                return true;
            }
        }

        return false;
    }

    public void GetCharacterInfo(out Sprite charSprite, out string monDesc, out string spell, out string hp, out string att, out string def)
    {
        charSprite = characterImage;
        monDesc = charDescripttion;
        spell = characterDict.characterDictionary[characterType].SpecialSpell;
        hp = characterDict.characterDictionary[characterType].HP.ToString();
        att = characterDict.characterDictionary[characterType].ATT.ToString();
        def = characterDict.characterDictionary[characterType].DEF.ToString();
    }

    public CastOfCharacters.CharacterList GetCharacterType()
    {
        return characterType;
    }
}
