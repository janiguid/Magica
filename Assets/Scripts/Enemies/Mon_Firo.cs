using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon_Firo : Enemy
{
    private void Update()
    {
        transform.SetPosition(Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime));
    }

    public override void ApplyDamage(float dam)
    {
        health -= dam;

        if (health <= 0) Destroy(gameObject);
    }
}
