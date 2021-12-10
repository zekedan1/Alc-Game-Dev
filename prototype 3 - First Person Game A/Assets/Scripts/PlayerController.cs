using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("movemont")]    
    public float moveSpeed;
    public float jumpForce;
    [Header("Controls")]
    public float lookSensitivity; // mouse look sensitivity
    public float maxLookX; // lowest down position we can look
    public float minLookX; // Highest up position we can look
    private float rotX; //Current X rotation of the camera
    [Header("GameObjects and Components")]
    private Camera cam; 
    private Rigidbody rb;
    private Weapons weapons;
    [Header("Stats")]
    public int curHP; 
    public int maxHP;

    void Awake()
    {
        // Get the components 
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapons = GetComponent<Weapons>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
            Die();
            
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    void Die()
    {

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
                weapons.Shoot();
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
    public void GiveHealth(int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    public void GiveAmmo ( int amountToGive)
    {
        weapons.curAmmo = Mathf.Clamp(weapons.curAmmo + amountToGive, 0, weapons.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapons.curAmmo, weapons.maxAmmo);
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
