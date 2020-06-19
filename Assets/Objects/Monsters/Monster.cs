using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, Damageable
{
    enum Type
    {
        Grass,
        Fire,
        Water
    };

    Type Element;
    public float Health;
    public float Speed;
    float DamageMultiplier;
    public float Damage;


    public float MaxPoint;

    private void Start()
    {
        //move this to object pooler!
        MaxPoint = GameObject.FindGameObjectWithTag("Shield").transform.position.y;
        //MaxPoint = Camera.main.WorldToScreenPoint(new Vector2(0, MaxPoint)).y;


        Health = 20;
        Speed = 2;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * Speed);


        if(transform.position.y < MaxPoint)
        {
            print("damaged player");
            //MonsterPool.AddToInactivePool(gameObject);
            gameObject.SetActive(false);
            
        }
    }


    public void ApplyDamage(float dam)
    {
        Health -= dam;

        if(Health <= 0)
        {
            //MonsterPool.AddToInactivePool(gameObject);
            print("got hit");
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        //ApplyDamage(5);
    }
}
