using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public float maxVelocity = 30f;
    Rigidbody rb;
    bool isAbleToMove = true;
    // Start is called before the first frame update

    void FixedUpdate() {
        
        float tempY = rb.velocity.y;
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
        rb.velocity = new Vector3(rb.velocity.x, tempY, rb.velocity.z);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {      
        if(isAbleToMove){
            rb.AddForce(Input.GetAxis("Vertical") * speed * transform.forward);
        }
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("antiGravityZone")){
            isAbleToMove = false;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("antiGravityZone")){
            isAbleToMove = true;
        }
    }
}
