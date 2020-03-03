using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{   
    public float rotateSpeed = 80f;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * Input.GetAxis("Horizontal") * rotateSpeed);
    }
}
