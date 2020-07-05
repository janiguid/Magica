using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector3 Target;
    [SerializeField] private float InitialSpeed;
    [SerializeField] private Color InitialColor;

    Type.ElementalType MyType;

    private float Speed;
    Vector2 OriginalPosition;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    MonsterDictionary monsterDict;

    private void Start()
    {
        print("TEA");
        OriginalPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Speed = InitialSpeed;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        monsterDict = new MonsterDictionary();

        InitialColor = Color.white;

        Recolor();
    }

    

    void Recolor()
    {
        if (MyType == Type.ElementalType.Grass)
        {
            InitialColor = Color.green;
        }
        else if (MyType == Type.ElementalType.Fire)
        {
            InitialColor = Color.red;
        }
        else if (MyType == Type.ElementalType.Water)
        {
            InitialColor = Color.blue;
        }
        else
        {
            InitialColor = Color.white;
        }

        spriteRenderer.color = InitialColor;
    }

    public void ResetPosition()
    {
        print("reset pos");
        gameObject.SetActive(false);
        transform.position = OriginalPosition;
        Target = Vector3.zero;
    }

    public void Activate(Vector3 target, Type.ElementalType type)
    {

        gameObject.SetActive(true);
        Target = target;

        MyType = type;
        Recolor();

    }

    // Update is called once per frame
    void Update()
    {
        //move towards target
        //if collide, deactivate and reset position

        if(Target != Vector3.zero)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Target, step);
        }

        if (transform.position == Target) ResetPosition();
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

                InitialDamage *= monsterDict.GetMultiplier(MyType, target.GetElement());

                if(InitialDamage == 0)
                {
                    print("Illegal combination detected");
                }
                print("Used " + MyType + " against " + target.GetElement() + " monster and dealt " + InitialDamage + " damage");
                target.ApplyDamage(InitialDamage);
                FindObjectOfType<Targeter>().ResetMin();
            }
            print("Found monster");
        }
        else
        {
            print("No Target Found");
        }
    }
}
