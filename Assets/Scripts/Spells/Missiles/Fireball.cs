using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Missile
{
    Vector2 corrected;
    // Start is called before the first frame update
    void Start()
    {
        spellEffect = new SpellEffect(speedDebuff, attackDebuff, defenseDebuff);
        if (lifeTime == 0) lifeTime = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != Vector2.zero)
        {
            if (lifeTime <= 0) Destroy(gameObject);

            lifeTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null)
        {
            collision.GetComponent<IModifiable>().ModifyStats(spellEffect);
            collision.GetComponent<IDamageable>().ApplyDamage(damageValue);

            Destroy(gameObject);
            //start coroutine and destroy here
        }
    }
}
