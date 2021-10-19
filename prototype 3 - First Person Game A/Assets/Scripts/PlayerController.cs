using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement
    public float moveSpeed;
    public float jumpForce;
    // Camera
    public float lookSensitivity; // mouse look sensitivity
    public float maxLookX; // lowest down position we can look
    public float minLookX; // Highest up position we can look
    private float rotX; //Current X rotation of the camera
    // GameObjects & components
    private Camera cam;
    private Rigidbody rb;
    private Weapons weapons;

    void Awake()
    {
        // Get the components 
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapons = GetComponent<Weapons>();
        Cursor.lockState = CursorLockMode.Locked;
    }





    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        if(Input.GetButtonDown("Jump"))
        Jump();
        if(Input.GetButton("Fire1"))
        {
            if(weapons.CanShoot())
            {
                weapons.shoot();
            }
        }
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;

        float z = Input.GetAxis("Vertical") * moveSpeed;

        //rb.velocity = new Vector3(x, rb.velocity.y, z);
        //Face the directin of the camera
        Vector3 dir = transform.right * x + transform.forward * z;
        //jump direcrtion
        dir.y = rb.velocity.y;
        // move in the direction camera
        rb.velocity = dir;


    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        }
    }
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        //Apply Rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
    }
}
