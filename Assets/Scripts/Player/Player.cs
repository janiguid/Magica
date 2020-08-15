﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spell
{
    [SerializeField] private float InitialButtonCooldown;
    [SerializeField] private float ButtonCooldown;
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private EffectsHandler MyEffectsHandler;

    private Targeter TargetLocator;
    private GameObject Blast;
    private Projectile MyProjectile;
    private void Awake()
    {
        TargetLocator = GameObject.FindObjectOfType<Targeter>();
        Blast = Instantiate(ProjectilePrefab);
        MyProjectile = Blast.GetComponent<Projectile>();
        MyProjectile.ResetPosition();
    }


    private void Start()
    {
    }
    private void Update()
    {
        //if (ButtonCooldown > 0) ButtonCooldown -= Time.deltaTime;
    }

    public override void InitializeElement()
    {

        //print("Successfully set to neutral");
        element = Type.ElementalType.Neutral;
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
        MyProjectile.Activate(TargetLocator.GetClosestMonster().transform.position, element);
        element = Type.ElementalType.Neutral;

        if (MyEffectsHandler)
        {
            MyEffectsHandler.PlayAudio();
            MyEffectsHandler.PlayEffects();
        }
        
    }
}
