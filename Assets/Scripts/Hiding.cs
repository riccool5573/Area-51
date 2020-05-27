using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    private GameObject locker;
    [SerializeField]    private Camera camera;
    [SerializeField]    private Transform Player;

    void Start()
    {
        locker = GameObject.FindGameObjectWithTag("locker");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                Transform objectHit = hit.transform;
                Debug.Log(objectHit.tag);
                Debug.Log(objectHit);
                if (objectHit.tag == "locker")
                {
                    Debug.Log("locker");
                    
                }
            }
        }
    }
}
