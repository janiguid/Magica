﻿using System.Collections;
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
    private SpellVisualizer visualizer;
    private void Awake()
    {
        targetLocator = GameObject.FindObjectOfType<Targeter>();
        blast = Instantiate(projectilePrefab);
        myProjectile = blast.GetComponent<Projectile>();
        myProjectile.ResetPosition();
    }


    private void Start()
    {
        if (visualizer == null) visualizer = FindObjectOfType<SpellVisualizer>();
        if (maxSpellLength <= 0) maxSpellLength = 3;
        spellMixer = new SpellMixer();
        SetElement(Type.ElementalSpellTypes.Neutral);
        currentSpell = "";
    }

    public override void InitializeElement()
    {

        //print("Successfully set to neutral");
        element = Type.ElementalSpellTypes.Neutral;
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
        }

        
        
    }

    void ResetSpells()
    {
        visualizer.EmptySlots();
        currentSpell = "";
    }

    public void SetElement(Type.ElementalSpellTypes elem)
    {
        element = elem;
        print("New element is: " + element);
    }

    public override void Trigger()
    {
        if(element == Type.ElementalSpellTypes.Neutral)
        {
            print("Choose a spell");
            return;
        }


        ResetSpells();
        myProjectile.Activate(targetLocator.GetClosestMonster().transform.position, element);
        element = Type.ElementalSpellTypes.Neutral;

        if (myEffectsHandler)
        {
            myEffectsHandler.PlayAudio();
            myEffectsHandler.PlayEffects();
        }
        
    }
}
