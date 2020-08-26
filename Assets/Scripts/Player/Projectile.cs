using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector3 target;
    [SerializeField] private float initialSpeed;
    [SerializeField] private Color initialColor;
    [SerializeField] private CameraShaker cameraShake;
    [SerializeField] private SpriteRenderer spriteRenderer;


     private Type.ElementalSpellTypes myType;
     private float speed;
     private Vector2 originalPosition;
     private MonsterDictionary monsterDict;

    private void Start()
    {
        originalPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        speed = initialSpeed;

        if (speed <= 0) speed = 5f;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        monsterDict = new MonsterDictionary();

        initialColor = Color.white;

        cameraShake = GameObject.FindObjectOfType<CameraShaker>();

        Recolor();
    }

    

    void Recolor()
    {
        if (myType == Type.ElementalSpellTypes.Grass)
        {
            initialColor = Color.green;
        }
        else if (myType == Type.ElementalSpellTypes.Fire)
        {
            initialColor = Color.red;
        }
        else if (myType == Type.ElementalSpellTypes.Water)
        {
            initialColor = Color.blue;
        }
        else
        {
            initialColor = Color.white;
        }

        spriteRenderer.color = initialColor;
    }

    public void ResetPosition()
    {
        gameObject.SetActive(false);
        transform.position = originalPosition;
        target = Vector3.zero;
    }

    public void Activate(Vector3 target, Type.ElementalSpellTypes type)
    {

        gameObject.SetActive(true);
        this.target = target;

        myType = type;
        Recolor();

    }

    // Update is called once per frame
    void Update()
    {
        //move towards target
        //if collide, deactivate and reset position

        if(target != Vector3.zero)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }

        if (transform.position == target) ResetPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isMonster = collision.gameObject.TryGetComponent<Monster>(out Monster potentialMonster);

        if (isMonster)
        {
            Monster target = collision.gameObject.GetComponent<Monster>();
            if (target.IsTargeted)
            {
                print("Found Target Monster");
                ResetPosition();
                float InitialDamage = 10f;

                InitialDamage *= monsterDict.GetMultiplier(myType, target.GetElement());

                if(InitialDamage == 0)
                {
                    print("Illegal combination detected");
                }
                print("Used " + myType + " against " + target.GetElement() + " monster and dealt " + InitialDamage + " damage");
                target.ApplyDamage(InitialDamage);
                FindObjectOfType<Targeter>().ResetMin();

                if (cameraShake != null)
                {
                    print("Should shake");
                    cameraShake.StartShake(0.1f, 0.15f, 0.15f);
                }
            }
            print("Found monster");
        }
        else
        {
            print("No Target Found");
        }
    }
}
