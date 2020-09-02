using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] private SO_GameInfoInstance gameInstance;
    [SerializeField] private GameObject startingTutorialPanel;

    [SerializeField] private Button[] levels;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if(gameInstance.TutorialCompleted == false)
        {
            startingTutorialPanel.SetActive(true);
            gameInstance.TutorialCompleted = true;
        }
        else
        {
            startingTutorialPanel.SetActive(false);
        }

        for(int i = 0; i < levels.Length; ++i)
        {
            if(i > gameInstance.FurthestLevel)
            {
                levels[i].interactable = false;
                levels[i].gameObject.GetComponent<Image>().color = Color.gray;
            }
        }
    }

    

}
