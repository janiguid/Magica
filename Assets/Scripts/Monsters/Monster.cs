using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{
    [SerializeField] private float initialHealth;
    [SerializeField] private float initialSpeed;
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damageMultiplier;
    [SerializeField] private float maxPoint;
    
    [SerializeField] private Type.ElementalType MyType;
    [SerializeField] private float Damage;

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

    private void Start()
    {
        Damage = 5f;
        maxPoint = GameObject.FindGameObjectWithTag("Shield").transform.position.y;

        
        initialHealth = 20;
        health = initialHealth;
        speed = initialSpeed;

        ReconfigureType();
    }

    private void OnEnable()
    {
        health = initialHealth;
        ResetColor();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);


        if(transform.position.y < maxPoint)
        {
            GameObject.FindObjectOfType<Shield>().ApplyDamage(Damage);
            gameObject.SetActive(false);
            
        }
    }


    public Type.ElementalType GetElement()
    {
        return MyType;
    }

    public void SetElement(Type.ElementalType elem)
    {
        MyType = elem;
    }


    public void ApplyDamage(float dam)
    {
        health -= dam;

        if(health <= 0)
        {
            //MonsterPool.AddToInactivePool(gameObject);
            print("got hit");
            gameObject.SetActive(false);
            //ReconfigureType();
        }
    }

    public void ReconfigureType()
    {
        //MyType = (Type.ElementalType)Random.Range(0, 3);
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
