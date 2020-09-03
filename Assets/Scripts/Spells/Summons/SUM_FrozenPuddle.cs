using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUM_FrozenPuddle : Summon
{

    private void Start()
    {
        StartCoroutine(LifeCountdown());
    }

    IEnumerator LifeCountdown()
    {
        while(lifeTime > 0)
        {
            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<ISusceptible>().ApplySlow(speedMod, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Enemy>().ClearDebuffs();
    }
}
