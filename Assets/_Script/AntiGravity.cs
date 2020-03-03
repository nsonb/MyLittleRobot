using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    // Start is called before the first frame update
    public float pushForce = 30;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("player")){
            other.attachedRigidbody.velocity = new Vector3(0,0,0);
            other.attachedRigidbody.AddForce( pushForce * transform.up);
            other.attachedRigidbody.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "player"){
            other.attachedRigidbody.useGravity = true;
        }
    }

}
