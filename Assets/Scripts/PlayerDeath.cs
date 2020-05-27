using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Text dtext;
    [SerializeField] private Text rtext;
    [SerializeField] private bool hitByEnemy;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
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
