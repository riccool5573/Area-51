using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    private GameObject button;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform Player;

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
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    //Application.Quit();

                }
            }
        }
    }
}