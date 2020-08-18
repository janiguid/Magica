using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateHandler : MonoBehaviour
{
    [SerializeField] private int desiredFramerate;

    private void Awake()
    {
        if (desiredFramerate < 30) desiredFramerate = 0;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = desiredFramerate;
    }


}
