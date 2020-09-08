using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Sprite portrait;
    [SerializeField] private float baseHealth;
    [SerializeField] private float baseAttack;
    [SerializeField] private float baseDefense;
    [SerializeField] private float baseSpeed;
    [SerializeField] private string specialSpell;

    [SerializeField] private SO_GameInfoInstance gameInstance;

    private void Awake()
    {
        CastOfCharacters castOfCharacters = new CastOfCharacters();
        CharacterData character = castOfCharacters.characterDictionary[gameInstance.CurrentChar];

        baseHealth = character.HP;
        baseAttack = character.ATT;
        baseDefense = character.DEF;

        specialSpell = character.SpecialSpell;
    }

    public Sprite GetSprite()
    {
        return portrait;
    }

    public float GetHealth()
    {
        return baseHealth;
    }

    public float GetAttack()
    {
        return baseAttack;
    }

    public float GetDefense()
    {
        return baseDefense;
    }
}
