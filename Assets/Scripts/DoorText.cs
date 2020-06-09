using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorText : MonoBehaviour
{
    [SerializeField] private Text doorClosedText;
    [SerializeField] private Text objective2Text;
    [SerializeField] KeyCard keyCard;

    // Start is called before the first frame update
    void Start()
    {
        doorClosedText.gameObject.SetActive(false);
        objective2Text.gameObject.SetActive(false);
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
            objective2Text.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Player" && keyCard.haveKeyCard)
        {
            doorClosedText.gameObject.SetActive(false);
            objective2Text.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorClosedText.gameObject.SetActive(false);
            objective2Text.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && keyCard.haveKeyCard)
        {
            doorClosedText.gameObject.SetActive(false);
            objective2Text.gameObject.SetActive(false);
        }
    }
}
