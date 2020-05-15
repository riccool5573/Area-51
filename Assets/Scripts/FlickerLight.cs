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
        this.gameObject.GetComponent<Light>().intensity = 2;
        timeDelay = Random.Range(0.07f, 0.25f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().intensity = 1;
        timeDelay = Random.Range(0.07f, 0.25f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().intensity = 2;
        isflickering = false;
    }
}
