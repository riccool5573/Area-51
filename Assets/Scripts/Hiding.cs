using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Hiding : MonoBehaviour
{
    private GameObject locker;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform teleportLocation;
    [SerializeField] private Transform teleportBackLocation;
    [SerializeField] private Text getInLocker;
    [SerializeField] private Text getOutLocker;

    private float timeDelay = 0.4f;
    [SerializeField] private bool isHiding = false;

    void Start()
    {
        locker = GameObject.FindGameObjectWithTag("locker");
        getInLocker.gameObject.SetActive(false);
        getOutLocker.gameObject.SetActive(false);
    }

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

                    isHiding = true;
                    if (isHiding == false)
                    {
                        return;
                    }
                    if (isHiding == true)
                    {
                        Player.transform.LookAt(teleportBackLocation);
                        getOutLocker.gameObject.SetActive(true);
                    }
                }
            }
        }
        else if (isHiding == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                //StartCoroutine(TeleportBack());
                Player.transform.position = teleportBackLocation.transform.position;
                Player.GetComponent<Collider>().enabled = true;
                Player.transform.rotation = Quaternion.identity; // bugfix // 
                getOutLocker.gameObject.SetActive(false);
                isHiding = false;
            }
        }


    }
    public bool GetHiding()
    {
        return isHiding;
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
    //    isHiding = false;
    //}
}
