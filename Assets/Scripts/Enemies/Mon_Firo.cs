using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon_Firo : Enemy, ISusceptible
{
    WaitForSeconds wait;
    private void Update()
    {
        transform.SetPosition(Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime));
    }

    public override void ApplyDamage(float dam)
    {
        health -= dam - defense/2;

        if (health <= 0) gameObject.SetActive(false);
    }

    public void ApplySlow(float speedMod, float duration)
    {
        if (speedMod == 0) speedMod = 1;
        speed *= speedMod;
    }

    public void ApplyDOT(float damage, float duration)
    {
        
    }



}
