using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{
    [SerializeField] private float initialHealth;
    [SerializeField] private float health;
    [SerializeField] private SpriteRenderer Sprite;
    [SerializeField] private Type.ElementalType MyType;
    [SerializeField] private float damage;
    [SerializeField] private bool isTargeted;
    
    
    public bool IsTargeted
    {
        get
        {
            return isTargeted;
        }
        set
        {
            isTargeted = value;
        }
    }

    Color InitialColor;

    private void Awake()
    {
        Sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        damage = 5f;

    }

    private void OnEnable()
    {
        Sprite = gameObject.GetComponent<SpriteRenderer>();
        health = initialHealth;
    }

    public Type.ElementalType GetElement()
    {
        return MyType;
    }

    public void ConfigureMonster(Type.ElementalType elemental, Sprite sprite, ref EffectsHandler fxHandler)
    {
        MyType = elemental;
        Sprite.sprite = sprite;

    }

    public void SetElement(Type.ElementalType elem)
    {
        MyType = elem;
    }


    public void ApplyDamage(float dam)
    {
        health -= dam;


        if (health <= 0)
        {
 
            gameObject.SetActive(false);
            
        }
    }



}
