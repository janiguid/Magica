using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class SO_GameInfoInstance : ScriptableObject
{
    [SerializeField] private bool tutorialCompleted;
    [SerializeField] private int currentLevel;
    [SerializeField] private int furthestLevel;

    public bool TutorialCompleted
    {
        get
        {
            return tutorialCompleted;
        }

        set
        {
            tutorialCompleted = value;
        }
    }
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }
    public int FurthestLevel
    {
        get
        {
            return furthestLevel;
        }
        set
        {
            furthestLevel = value;
        }
    }

}
