using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    bool isJumping;
    public float jumpForce = 30;
    public float maxVelocity = 30f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
    }

    // void FixedUpdate() {
        
    //     rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);   
    // }

    // Update is called once per frame
    void Update()
    {
        if(isJumping == false && Input.GetKeyDown("space"))
        {
            rb.AddForce( jumpForce * transform.up, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Ground")){
            isJumping = false;
        }
    }

    void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag("Ground")){
            isJumping = true;
        }
    }
}
