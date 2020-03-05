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
        if(isAbleToMove && Input.GetAxis("Vertical") !=0) {
            rb.velocity = CalculateSpeed(speed);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {   
        
        if(isAbleToMove){
            //rb.AddForce(Input.GetAxisRaw("Vertical") * speed * transform.forward); 
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

    Vector3 CalculateSpeed(float speed) {
        Vector3 movement = new Vector3(0, 0, speed);
        float coefficient = (float)System.Math.Sqrt(movement.magnitude/transform.forward.magnitude);
        if(Input.GetAxis("Vertical") > 0) {
            return new Vector3(transform.forward.x * coefficient, rb.velocity.y, transform.forward.z * coefficient);
        } else if (Input.GetAxis("Vertical") < 0) {
            return new Vector3(-transform.forward.x * coefficient, rb.velocity.y, -transform.forward.z * coefficient);
        } else {
            return new Vector3(0, rb.velocity.y, 0);
        }
        
        
        
    }
}
