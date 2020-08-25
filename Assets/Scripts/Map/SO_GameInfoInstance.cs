using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class SO_GameInfoInstance : ScriptableObject
{
    [SerializeField]private bool tutorialCompleted;

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
}
