using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnspeed;
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
        //Rotate tank left and right
        transform.Rotate(vector3.up,  turnSpeed * Time.deltaTime * hInput);
    }
}
