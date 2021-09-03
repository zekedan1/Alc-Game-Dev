using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.00f;
    public float turnspeed;
    public bool hInput;
    public bool vInput;


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
