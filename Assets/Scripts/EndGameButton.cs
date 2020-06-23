using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    private GameObject button;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform Player;

    [SerializeField] private GameObject winGameText;
    [SerializeField] private GameObject endScreen;
    private float timeDelay = 5f;

    void Start()
    {
        button = GameObject.FindGameObjectWithTag("Button");
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
                if (objectHit.tag == "Button")
                {
                    StartCoroutine(EndText());
                }
            }
        }
    }

    private IEnumerator EndText()
    {
        winGameText.SetActive(true);
        yield return new WaitForSeconds(timeDelay);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        endScreen.SetActive(true);
    }
}