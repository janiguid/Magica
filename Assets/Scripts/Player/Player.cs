using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Cosmetics")]
    [SerializeField] private GameObject projectilePrefab;

    [Header ("Spell Mechanics")]
    [SerializeField] private int maxSpellLength;

    protected Type.ElementalSpellTypes element;
    public bool hasValidSpell;
    private float buttonCooldown;
    private string currentSpell;
    private SpellMixer spellMixer;
    private SpellBook spellBook;
    private Targeter targetLocator;
    private GameObject blast;
    private Projectile myProjectile;
    private SpellVisualizer visualizer;
    private void Awake()
    {
        targetLocator = GameObject.FindObjectOfType<Targeter>();

    }


    private void Start()
    {
        if (spellBook == null) spellBook = FindObjectOfType<SpellBook>();
        if (visualizer == null) visualizer = FindObjectOfType<SpellVisualizer>();
        if (maxSpellLength <= 0) maxSpellLength = 3;
        spellMixer = new SpellMixer();
        SetElement(Type.ElementalSpellTypes.Neutral);
        currentSpell = "";
    }

    private void Update()
    {
        if (buttonCooldown > 0)
        {
            buttonCooldown -= Time.deltaTime;
            return;
        }


        if (hasValidSpell == false) return;
        if (Input.touchCount == 1 || Input.GetMouseButtonDown(0))
        {
            

            Vector2 worldPos = Vector2.zero;
            if (Input.touchCount == 1)
            {
                Touch point = Input.GetTouch(0);
                print(point.position);
                worldPos = ConvertPosition(point.position);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                worldPos = ConvertPosition(Input.mousePosition);
            }

            if (worldPos == Vector2.zero)
            {
                print("Error in converting inputs!");
            }

            //fire projectile here
            CastSpell(worldPos);
            buttonCooldown = 0.3f;
        }
    }

    void CastSpell(Vector2 target)
    {
        print("Drawing Line");
        Debug.DrawLine(transform.position, target, Color.red, 2);

        blast = Instantiate (spellBook.GetSpell(element));
        blast.transform.position = transform.position;
        blast.GetComponent<Spell>().SetTarget(target);
        ResetSpells();
        //reset spell
    }

    Vector2 ConvertPosition(Vector2 pointToBeConverted)
    {
        return Camera.main.ScreenToWorldPoint(pointToBeConverted);
    }



    public void AddToSpellStack(Type.ElementalSpellTypes type)
    {
        if (currentSpell.Length == maxSpellLength) return;
        currentSpell += spellMixer.GetRuneType(type);

        if (visualizer)
        {
            visualizer.RefreshUI(type);
        }
        else
        {
            print("Missing visualizer!");
        }
        
        print(currentSpell);

        if (currentSpell.Length >= maxSpellLength)
        {
            FinalizeSpell();
        }
    }

    private void FinalizeSpell()
    {
        if (currentSpell.Length != maxSpellLength)
        {
            
            print("Length of spell isn't correct. ERROR");
        }

        Type.ElementalSpellTypes temp = spellMixer.MixSpells(currentSpell);

        if(temp == Type.ElementalSpellTypes.Neutral)
        {
            print("ERROR: Spell isn't inside Spell Mixer");
            ResetSpells();
        }
        else
        {
            SetElement(temp);
            hasValidSpell = true;
        }

        
        
    }

    void ResetSpells()
    {
        visualizer.EmptySlots();
        currentSpell = "";
        hasValidSpell = false;
    }

    public void SetElement(Type.ElementalSpellTypes elem)
    {
        element = elem;
        print("New element is: " + element);
    }

 
    
}
