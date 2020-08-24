using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICloser : MonoBehaviour
{
    [SerializeField] private GameObject UIElementToClose;

    public void CloseWindow()
    {
        UIElementToClose.SetActive(false);
    }
}
