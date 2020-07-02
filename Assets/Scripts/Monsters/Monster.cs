using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{
    public float InitialHealth;
    public float InitialSpeed;
    public float Health;
    public float Speed;
    float DamageMultiplier;

    Color InitialColor;

    public bool isTargeted;

    [SerializeField]
    private Type.ElementalType MyType;

    [SerializeField]
    private float Damage;


    public float MaxPoint;

    private void Start()
    {
        Damage = 5f;
        MaxPoint = GameObject.FindGameObjectWithTag("Shield").transform.position.y;

        
        InitialHealth = 20;
        Health = InitialHealth;
        Speed = InitialSpeed;

        ReconfigureType();
    }

    private void OnEnable()
    {
        Health = InitialHealth;
        ResetColor();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * Speed);


        if(transform.position.y < MaxPoint)
        {
            GameObject.FindObjectOfType<Shield>().ApplyDamage(Damage);
            gameObject.SetActive(false);
            
        }
    }

    public Type.ElementalType GetElement()
    {
        return MyType;
    }


    public void ApplyDamage(float dam)
    {
        Health -= dam;

        if(Health <= 0)
        {
            //MonsterPool.AddToInactivePool(gameObject);
            print("got hit");
            gameObject.SetActive(false);
            ReconfigureType();
        }
    }

    public void ReconfigureType()
    {
        MyType = (Type.ElementalType)Random.Range(0, 3);
        ResetColor();

    }

    public void ResetColor()
    {
        if (MyType == Type.ElementalType.Grass)
        {
            InitialColor = Color.green;
        }
        else if (MyType == Type.ElementalType.Fire)
        {
            InitialColor = Color.red;
        }
        else if (MyType == Type.ElementalType.Water)
        {
            InitialColor = Color.blue;
        }
        else
        {
            InitialColor = Color.white;
        }

        gameObject.GetComponent<SpriteRenderer>().color = InitialColor;
    }
}
