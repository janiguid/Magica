using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Vector3 Target;
    Type.ElementalType Type;
    [SerializeField]
    private float initialSpeed;
    private float speed;
    Vector2 OriginalPosition;

    private void Start()
    {
        OriginalPosition = GameObject.FindObjectOfType<Player>().transform.position;
        speed = initialSpeed;
    }

    public void ResetPosition()
    {
        gameObject.SetActive(false);
        transform.position = OriginalPosition;
        Target = Vector3.zero;
    }

    public void Activate(Vector3 target, Type.ElementalType type)
    {
        gameObject.SetActive(true);
        Target = target;
        Type = type;
    }

    // Update is called once per frame
    void Update()
    {
        //move towards target
        //if collide, deactivate and reset position

        if(Target != Vector3.zero)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Target, step);
        }
    }
}
