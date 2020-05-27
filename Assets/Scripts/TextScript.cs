using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    [SerializeField] private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Current Objective: Find The Big Red Button";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
