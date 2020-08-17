using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spell
{
    [Header ("Cosmetics")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private EffectsHandler myEffectsHandler;

    [Header ("Spell Mechanics")]
    [SerializeField] private int maxSpellLength;


    private string currentSpell;
    private SpellMixer spellMixer;
    private Targeter targetLocator;
    private GameObject blast;
    private Projectile myProjectile;
    private void Awake()
    {
        targetLocator = GameObject.FindObjectOfType<Targeter>();
        blast = Instantiate(projectilePrefab);
        myProjectile = blast.GetComponent<Projectile>();
        myProjectile.ResetPosition();
    }


    private void Start()
    {
        if (maxSpellLength <= 0) maxSpellLength = 3;
        spellMixer = new SpellMixer();
    }
    private void Update()
    {
    }

    public override void InitializeElement()
    {

        //print("Successfully set to neutral");
        element = Type.ElementalType.Neutral;
    }

    public void AddToSpellStack(Type.ElementalType type)
    {
        
        currentSpell += spellMixer.GetRuneType(type);
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

        Type.ElementalType temp = spellMixer.MixSpells(currentSpell);

        if(temp == Type.ElementalType.Neutral)
        {
            print("Unknown spell was used. Resetting spells");
        }
        else
        {
            SetElement(temp);
        }

        currentSpell = "";
    }

    public void SetElement(Type.ElementalType elem)
    {
        element = elem;
        print("New element is: " + element);
    }

    public override void Trigger()
    {
        if(element == Type.ElementalType.Neutral)
        {
            print("Choose a spell");
            return;
        }


        //ButtonCooldown = InitialButtonCooldown;
        myProjectile.Activate(targetLocator.GetClosestMonster().transform.position, element);
        element = Type.ElementalType.Neutral;

        if (myEffectsHandler)
        {
            myEffectsHandler.PlayAudio();
            myEffectsHandler.PlayEffects();
        }
        
    }
}
