using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform Player;

    [SerializeField] private GameObject winGameText;
    private float timeDelay = 5f;

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
                    
                    //Application.Quit();

                }
            }
        }
    }

    private IEnumerator EndText()
    {
        winGameText.SetActive(true);
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}