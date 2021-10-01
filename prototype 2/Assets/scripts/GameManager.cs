using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasKey;
    public bool isDoorLocked;


    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        isDoorLocked = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if(hasKey && !isDoorLocked)
        {
            print("you exit out the door into another room! Mr Boney Pants Guy...NOOOOOO!");
        }
    }
}
