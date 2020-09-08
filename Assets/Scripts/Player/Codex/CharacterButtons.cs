using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButtons : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite characterImage;
    [SerializeField] private string charDescripttion;
    [SerializeField] private string specialSpell;


    SpriteRenderer mySpriteRenderer;
    Bounds bounds;
    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (mySpriteRenderer == null) gameObject.AddComponent<SpriteRenderer>();


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

    public void GetMonsterInformation(out Sprite charSprite, out string monDesc, out string spell)
    {
        charSprite = characterImage;
        monDesc = charDescripttion;
        spell = specialSpell;
    }
}
