using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private bool isflickering = false;
    private float timeDelay;

    void Update()
    {
        if (!isflickering)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isflickering = true;
        this.gameObject.GetComponent<Light>().intensity = 1.5f;
        timeDelay = Random.Range(0.1f, 0.5f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().intensity = 1;
        timeDelay = Random.Range(0.1f, 0.5f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().intensity = 1.5f;
        isflickering = false;
    }
}
