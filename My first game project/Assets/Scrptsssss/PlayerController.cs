using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private float turnspeed;
    private bool hInput;
    private bool vInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        hInput = hInput.GetAxis("Horizontal");
        VInput = hInput.GetAxis("Vertical");


    
        //move tanks forward
        transform.Translate(vector3.forward * speed * Time.deltaTime * vInput);

        transform.Translate(vector3.right * speed * Time.deltaTime * hInput);
    }
}
