﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    [SerializeField]
    private Camera camera;
    private GameObject door;
    [SerializeField] private KeyCard keyCard;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //i know this is very bad code but i don't have enough time to actually make a good solution
        if (Input.GetKeyDown(KeyCode.C))
        {
            UnityEngine.Debug.Log(keyCard.haveKeyCard);
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                GameObject objectHit = hit.transform.gameObject;

                if (objectHit.tag == "Scanner" || objectHit.tag == "Locked Scanner" && keyCard.haveKeyCard)
                {

                    door = objectHit;
                    GameObject Door = objectHit.gameObject;
                    Dooropen dooropen = Door.GetComponent<Dooropen>();
                    bool Open = dooropen.GetDoorOpen();
                    if (Open)
                        dooropen.SetDoorOpen(false);
                    else
                        dooropen.SetDoorOpen(true);

                    UnityEngine.Debug.Log(Open);
                }
            }
        }
    }


    

}

