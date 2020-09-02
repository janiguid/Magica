using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapElement : MonoBehaviour
{
    [SerializeField] private int gameLevel;
    [SerializeField] private SO_LevelConfig myLevel;
    [SerializeField] private SO_LevelConfig placeholderLevel;
    [SerializeField] private SO_GameInfoInstance gameInstance;
    [SerializeField] private int mapLevel;

    public void ConfigureLevel()
    {
        placeholderLevel.SetMonsterOrder(myLevel.GetMonsterOrder());

        gameInstance.PreviousLevel = gameLevel;

        SceneManager.LoadScene(gameLevel);

        if (gameInstance)
        {
            gameInstance.CurrentLevel = mapLevel;
        }
    }

}
