using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tank;
    private Vector3 offset = new Vector3(0,50,-80);

    // Update is called once per frame
    void Update()
    {
        transform.position = tank.transform.position + offset;
    }
}
