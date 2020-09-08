using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{



    [SerializeField] protected Vector2 target;
    [SerializeField] protected float lifeTime;
    protected SpellEffect spellEffect;


    private void Start()
    {
        target = Vector2.zero;
    }

    public virtual void AddCharacterModifiers(float plusAtt, float plusSpd) { }

    public virtual void SetTarget(Vector2 tgt, Vector2 playerPosition) { }

}
