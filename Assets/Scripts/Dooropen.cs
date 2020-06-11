using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Dooropen : MonoBehaviour
{
    [SerializeField]
    private GameObject Door;
    private bool doorOpen;
    private float Offset = 2.82f;
    private Vector3 OriginPos;
    // Start is called before the first frame update
    void Start()
    {
        OriginPos = Door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            
            if (Door.transform.position.z != -Offset)
            {
                Vector3 temp = new Vector3(0, 0, -Offset);
                Door.transform.position += Mathf.Floor(Time.time * 1) * temp;
                StartCoroutine(Timer());
            }
        }
        else if (!doorOpen)
        {
            if(Door.transform.position != OriginPos)
            {
                UnityEngine.Debug.Log("Closing");

                Door.transform.position = OriginPos;
                StopCoroutine(Timer());
            }
        }
    }

   public void SetDoorOpen(bool open)
    {
        doorOpen = open;
    }
    public bool GetDoorOpen()
    {
        return doorOpen;
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        doorOpen = false;
    }
}
