using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuElement : MonoBehaviour
{
    [SerializeField] private SO_GameInfoInstance gameInfoInstance;
    [SerializeField] private int SceneToGoTo;

    public void Clicked()
    {
        if(gameInfoInstance) gameInfoInstance.PreviousLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneToGoTo);
    }
    
    public void Return()
    {
        if (gameInfoInstance)
        {
            SceneManager.LoadScene(gameInfoInstance.PreviousLevel);
        }
        else
        {
            print("ERROR: Missing game info instance");
        }
        
    }
}
