using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] AudioSource enemyDeathSound;

    private IEnumerator ShakeCamera(float duration, float xMagnitude, float yMagnitude)
    {
        Vector3 originalPosition = transform.localPosition;
        float xDelta = xMagnitude / 2;
        float yDelat = yMagnitude / 2;
        float counter = 0;

        while(counter < duration)
        {
            transform.localPosition += new Vector3(Random.Range(-xDelta, xDelta), Random.Range(-yDelat, yDelat),
                originalPosition.z);

            counter += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }

    public void StartShake(float duration, float xMagnitude, float yMagnitude)
    {
        StartCoroutine(ShakeCamera(duration, xMagnitude, yMagnitude));
        if (enemyDeathSound)
        {
            enemyDeathSound.Play();
        }
        
    }
}
