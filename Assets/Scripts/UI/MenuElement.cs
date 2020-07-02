using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuElement : MonoBehaviour
{

    [SerializeField] private int SceneToGoTo;

    public void Clicked()
    {
        SceneManager.LoadScene(SceneToGoTo);
    }
    
}
