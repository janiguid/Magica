using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{

    public float Health;
    public float Speed;
    float DamageMultiplier;

    [SerializeField]
    private float Damage;


    public float MaxPoint;

    private void Start()
    {
        Damage = 5f;
        MaxPoint = GameObject.FindGameObjectWithTag("Shield").transform.position.y;

        Health = 20;
        Speed = 2;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * Speed);


        if(transform.position.y < MaxPoint)
        {
            print("damaged player");
            GameObject.FindObjectOfType<Shield>().ApplyDamage(Damage);
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
