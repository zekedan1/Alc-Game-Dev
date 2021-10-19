using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;
    public float bulletSpeed;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;

    void Awake()
    {
        if(GetComponent<PlayerController>())
        {
            isPlayer = true;
        }
    }
    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
                return true;
        }

        return false;
    }
    public void shoot()
    {
        lastShootTime = Time.time;
        curAmmo--;

        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);

        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
