using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCharacter : MonoBehaviour
{
    [SerializeField] private CastOfCharacters.CharacterList potentialCharacter;
    [SerializeField] private SO_GameInfoInstance gameInstance;

    public CastOfCharacters.CharacterList PotentialCharacter
    {
        get
        {
            return potentialCharacter;
        }

        set
        {
            potentialCharacter = value;
        }
    }

    public void ConfirmCharacter()
    {
        gameInstance.CurrentChar = potentialCharacter;
    }
}
