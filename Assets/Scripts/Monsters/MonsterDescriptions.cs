using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDescriptions : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite monsterImage;
    [SerializeField] private string monsterDescription;
    [SerializeField] private string weakness;


    SpriteRenderer mySpriteRenderer;
    Bounds bounds;
    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (mySpriteRenderer == null) gameObject.AddComponent<SpriteRenderer>();


        monsterImage = mySpriteRenderer.sprite;
        bounds = mySpriteRenderer.bounds;
    }

    public bool Interact(float posX, float posY)
    {
        print("My bounds: " + bounds);
        
        if(posX < bounds.max.x && posX > bounds.min.x)
        {
            if(posY < bounds.max.y && posY > bounds.min.y)
            {
                return true;
            }
        }

        return false;
    }

    public void GetMonsterInformation(out Sprite monSprite, out string monDef, out string monWeakness)
    {
        monSprite = monsterImage;
        monDef = monsterDescription;
        monWeakness = weakness;
    }
}


