using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject deur;
    [SerializeField]
    private Camera camera;
    private bool doorOpen;
    private GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        deur = GameObject.FindGameObjectWithTag("Deur");
    }

    // Update is called once per frame
    void Update()
    {
        //i know this is very bad code but i don't have enough time to actually make a good solution
        if (doorOpen)
        {
            if (door.transform.position.z != -2.82)
            {
                Vector3 temp = new Vector3(0, 0, -2.28f);
                door.transform.position += Mathf.Floor(Time.time * 30) * temp;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                Transform objectHit = hit.transform;
                Debug.Log(objectHit.tag);
                if (objectHit.tag == "Deur")
                {
                    Debug.Log("duer");
                    door = objectHit.gameObject;
                    doorOpen = true;
                }
            }
        }
    }


    

}

