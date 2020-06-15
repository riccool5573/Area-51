using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScanner : MonoBehaviour
{

    /// <summary>
    /// The only reason this code exists is because i need two different objects to do the same thing to the same object.
    /// There might be a better way of doing this but this'll work for now.
    /// </summary>
    [SerializeField]
    private GameObject scanner;
    private Dooropen dooropen;
    // Start is called before the first frame update
    void Start()
    {
        dooropen = scanner.GetComponent<Dooropen>();
    }

    // Update is called once per frame
    public void Send(bool open)
    {
        dooropen.SetDoorOpen(open);
     
    }
    public bool GetOpen()
    {
        //this code is kinda disgusting not gonna lie
        bool Open = dooropen.GetDoorOpen();
        return Open;
    }
}
