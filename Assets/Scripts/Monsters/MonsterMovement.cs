using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    
    [SerializeField] private float initialSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float maxPoint;
    [SerializeField] private float damage;

    private void Start()
    {
        maxPoint = GameObject.FindGameObjectWithTag("Shield").transform.position.y;

        speed = initialSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);

        if (transform.position.y < maxPoint)
        {
            GameObject.FindObjectOfType<Shield>().ApplyDamage(damage);
            gameObject.SetActive(false);

        }
    }
}
