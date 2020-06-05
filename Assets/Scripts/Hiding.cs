using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    private GameObject locker;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform teleportLocation;
    [SerializeField] private Transform teleportBackLocation;

    private float timeDelay = 0.4f;
    [SerializeField] private bool isHdiding = false;

    void Start()
    {
        locker = GameObject.FindGameObjectWithTag("locker");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                Transform objectHit = hit.transform;
                Debug.Log(objectHit.tag);
                Debug.Log(objectHit);
                if (objectHit.CompareTag("locker"))
                {
                    //StartCoroutine(Hide());
                    Player.GetComponent<Collider>().enabled = false;
                    Player.transform.position = objectHit.transform.GetChild(57).position;
                    teleportBackLocation = objectHit.transform.GetChild(58);
                    isHdiding = true;
                }

            }
        }
        else if (isHdiding == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                //StartCoroutine(TeleportBack());
                Player.transform.position = teleportBackLocation.transform.position;
                Player.GetComponent<Collider>().enabled = true;
                isHdiding = false;
            }
        }

    }
    public bool GetHiding()
    {
        return isHdiding;
    }
    //IEnumerator Hide()
    //{
    //    teleportLocation = locker.transform.GetChild(57);
    //    locker.GetComponent<BoxCollider>().enabled = false;
    //    yield return new WaitForSeconds(timeDelay);
    //    Debug.Log(locker.transform.childCount);
    //    Debug.Log(teleportLocation);
    //    Player.transform.position = teleportLocation.transform.position;


    //}

    //IEnumerator TeleportBack()
    //{
    //    timeDelay = 0.08f;
    //    teleportBackLocation = locker.transform.GetChild(58);
    //    yield return new WaitForSeconds(timeDelay);
    //    Player.transform.position = teleportBackLocation.transform.position;
    //    locker.GetComponent<BoxCollider>().enabled = true;
    //    isHdiding = false;
    //}
}
