using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Net;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Text dtext;
    [SerializeField] private Text rtext;
    [SerializeField] private bool hitByEnemy;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        UnityEngine.Debug.Log(hit.gameObject.CompareTag("Enemy"));
        if (hit.gameObject.CompareTag("Enemy"))
        {
           UnityEngine.Debug.Log("ded");
            dtext.text = "You Died";
            rtext.text = "Press 'R' To Restart";
            Time.timeScale = 0.1f;
            hitByEnemy = true;
        }
        if (Input.GetKey(KeyCode.R) && hitByEnemy)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnTriggerEnter(Collider hit)
    {
        UnityEngine.Debug.Log(hit.gameObject.CompareTag("Enemy"));
        if (hit.gameObject.CompareTag("Enemy"))
        {
            UnityEngine.Debug.Log("ded");
            dtext.text = "You Died";
            rtext.text = "Press 'R' To Restart";
            Time.timeScale = 0.1f;
            hitByEnemy = true;
        }
        if (Input.GetKey(KeyCode.R) && hitByEnemy)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
