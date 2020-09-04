using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUM_FrozenPuddle : Summon
{

    private void Start()
    {
        StartCoroutine(LifeCountdown());
        //gameObject.GetComponent<CircleCollider2D>().enabled = false;

        //Collider2D col = Physics2D.OverlapCircle(gameObject.GetComponent<CircleCollider2D>().bounds.center,
        //    gameObject.GetComponent<CircleCollider2D>().radius, layer, -4f, 4f);


        //if (col)
        //{
        //    print(col.transform.position);
        //    Destroy(col.gameObject);
        //}
        //gameObject.GetComponent<CircleCollider2D>().enabled = true;

    }

    IEnumerator LifeCountdown()
    {
        while(lifeTime > 0)
        {
            lifeTime -= Time.fixedDeltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Summon>() != null)
        {
            if(lifeTime < collision.GetComponent<Summon>().GetLifeTime())
            {
                Destroy(gameObject);
            }
        }
        if (collision.GetComponent<ISusceptible>() != null)
        {
            collision.GetComponent<ISusceptible>().ApplySlow(speedMod, 0);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().ClearDebuffs();
        }
        
    }
}
