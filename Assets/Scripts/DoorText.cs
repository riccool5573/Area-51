using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorText : MonoBehaviour
{
    [SerializeField] private Text doorClosedText;

    // Start is called before the first frame update
    void Start()
    {
        doorClosedText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorClosedText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorClosedText.gameObject.SetActive(false);
        }
    }
}
