using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{
    [SerializeField] private float initialHealth;
    [SerializeField] private float health;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Type.MonsterTypes myType;
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

    private void Awake()
    {
        RefreshReferences();
    }

    private void Start()
    {
        damage = 5f;
    }

    private void RefreshReferences()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        health = initialHealth;
    }

    private void OnEnable()
    {
        RefreshReferences();
    }

    public float GetHealth()
    {
        return health;
    }

    public Type.MonsterTypes GetElement()
    {
        return myType;
    }

    public void ConfigureMonster(Type.MonsterTypes elemental, Sprite sprite, ref EffectsHandler fxHandler)
    {
        myType = elemental;
        this.sprite.sprite = sprite;

    }

    public void ConfigureMonster(Type.MonsterTypes elemental, Sprite sprite)
    {
        myType = elemental;
        this.sprite.sprite = sprite;

    }

    public void SetElement(Type.MonsterTypes elem)
    {
        myType = elem;
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
