using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelButton : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject nextPanel;


    public void DeactivatePanel()
    {
        print("Blah");

        if (nextPanel)
        {
            nextPanel.SetActive(true);
        }

        panel.SetActive(false);
    }


}
