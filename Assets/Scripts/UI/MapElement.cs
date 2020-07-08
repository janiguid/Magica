using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapElement : MonoBehaviour
{
    [SerializeField] private int mapLevel;
    [SerializeField] private SO_LevelConfig myLevel;
    [SerializeField] private SO_LevelConfig placeholderLevel;

    public void ConfigureLevel()
    {
        placeholderLevel.SetOrdering(myLevel.GetOrdering());
        SceneManager.LoadScene(mapLevel);
    }

}
