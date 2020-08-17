using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell:MonoBehaviour
{

    [SerializeField] protected Type.ElementalType element;
    [SerializeField] protected Player player;


    private void Start()
    {

        player = GameObject.FindObjectOfType<Player>();
        InitializeElement();
    }

    public virtual void InitializeElement()
    {
        print("Set base element. No bueno");
    }

    public virtual void Trigger() {
       player.AddToSpellStack(element);           
    }


}
