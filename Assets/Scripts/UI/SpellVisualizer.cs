using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellVisualizer : MonoBehaviour
{
    public Image[] spellIndicators;
    private int iterator;

    //0 - grass
    //1 - fire
    //2 - water
    [SerializeField] private Sprite[] spellSprites;


    public void RefreshUI(Type.ElementalSpellTypes type)
    {
        spellIndicators[iterator].sprite = spellSprites[(int)type];
        ++iterator;
    }

    public void EmptySlots()
    {
        for(int i = 0; i < spellIndicators.Length; ++i)
        {
            spellIndicators[i].sprite = null;
        }
        iterator = 0;
    }
}
