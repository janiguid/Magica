using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private Spell[] Observers;

    [SerializeField]
    private float ButtonCooldown;
    [SerializeField]
    private float MainButtonCooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Observers = FindObjectsOfType<Spell>();
    }

    // Update is called once per frame
    void Update()
    {
        //loop through observers and send location of clicked point


        if (ButtonCooldown > 0)
        {
            ButtonCooldown -= Time.deltaTime;
            return;
        }



        if (Input.touchCount == 1)
        {
            Touch point = Input.GetTouch(0);

            print("Toucha me!");
            for(int i = 0; i < Observers.Length; ++i)
            {
                if(Observers[i].Trigger(point.position.x, point.position.y))
                {
                    ButtonCooldown = MainButtonCooldown;
                    break;
                }
            }
        }
    }
}
