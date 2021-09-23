using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnspeed = 10.0f;
    private float hInput;
    private float vInput;

    public float xRange = 9.17f;
    public float yRange = 4.45f;

    public GameObject projectile;
    public Vector3 offset = new Vector3(0,1,0);

    // Update is called once per frame
    void Update()
    {
        // Gathering Keyboard input for movement
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Makes the Pc rotate left and right
        transform.Rotate(Vector3.forward, turnspeed * speed * Time.deltaTime * hInput);
        // Makes the pc move forward and back
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);

        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } 

         if(transform.position.y > yRange)
        {
            // Vector3(x,y,z)
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position + offset, projectile.transform.rotation);
        }
    }
} 