using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCard : MonoBehaviour
{
    [SerializeField] private Text pickUpText;
    [SerializeField] private GameObject keyy;
    private bool pickUpAllowed;
    public bool haveKeyCard;

    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
        haveKeyCard = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pickUpAllowed && Input.GetKey(KeyCode.C))
        {
            PickUp();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    void PickUp()
    {
        keyy.SetActive(false);
        pickUpText.gameObject.SetActive(false);
        haveKeyCard = true;
    }
}
