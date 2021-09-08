using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    private float hInput;
    private float vInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");


    
        //move tanks forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);

        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * hInput);
    }
}
