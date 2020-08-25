using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private SO_GameInfoInstance gameInstance;
    [SerializeField] private GameObject startingTutorialPanel;

    // Start is called before the first frame update
    void Start()
    {
        if(gameInstance.TutorialCompleted == false)
        {
            startingTutorialPanel.SetActive(true);
            gameInstance.TutorialCompleted = true;
        }
        else
        {
            startingTutorialPanel.SetActive(false);
        }
    }

}
