using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell:MonoBehaviour
{

    [SerializeField] protected Type.ElementalType element;



    private void Start()
    {


        InitializeElement();
    }

    public virtual void InitializeElement()
    {
        print("Set base element. No bueno");
    }

    public virtual void Trigger() {
        GameObject.FindObjectOfType<Player>().SetElement(element);           
    }


}
