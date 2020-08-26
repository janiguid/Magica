using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shield : MonoBehaviour, IDamageable
{
    [SerializeField] private SO_PlayerStats MyStats;
    [SerializeField] private GameObject gameOverButton;
    [SerializeField] private float MyHealth;
    // Start is called before the first frame update
    void Start()
    {
        MyHealth = MyStats.ShieldHealth;
    }


    public void ApplyDamage(float dam)
    {
        MyHealth -= dam;

        if (MyHealth <= 0)
        {
            if (gameOverButton)
            {
                gameOverButton.SetActive(true);
                gameOverButton.GetComponentInChildren<Text>().text = "Failed";
            }
            else
            {
                SceneManager.LoadScene(1);
            }
            
        }
    }

    public float GetHealth()
    {
        return MyHealth;
    }

}
