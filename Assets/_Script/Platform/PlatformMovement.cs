using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1;
    public List<GameObject> nodes;
    int targetNode = 1;
    private void Start() {
        //transform.position = nodes[0].transform.position;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (nodes[targetNode].transform.position - transform.position)/10 * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.CompareTag("node")) {
            if(targetNode + 1 == nodes.Count) {
                targetNode = 0;
            } else {
                targetNode++;
            }
        }
    }
}
