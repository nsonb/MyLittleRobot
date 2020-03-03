using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1200;
    float lifeTime = 0;
    bool isShooting = false;
    bool touchEnemy = false;
    Rigidbody rb;
    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        isShooting = true;
    }
    void Update() {
        if(isShooting) 
        {
            lifeTime += Time.deltaTime;
        }
    }

    // get object lifetime
    public float GetLifeTime() {
        return lifeTime;
    }

    // return value if object is shooting or not
    public bool CheckShoot()
    {
        return isShooting;
    }

    public bool CheckTouch() 
    {
        return touchEnemy;
    }

    // disable and reset object velocity, shooting state, and lifetime
    public void Disable() 
    {
        print("disabling");
        rb.velocity = new Vector3(0,0,0);
        lifeTime = 0;
        isShooting = false;
        touchEnemy =false;
        gameObject.SetActive(false);
    }

    // reactivate object, start the lifetime count
    public void Enable() {
        gameObject.SetActive(true);
        isShooting = true;

    }
    public void Shoot(Transform shootPoint, Vector3 force)
    {
        transform.position = shootPoint.transform.position;
        rb.AddForce(shootPoint.transform.forward*speed);
        rb.AddRelativeTorque(shootPoint.transform.forward * speed * 10);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("enemy")){
            touchEnemy = true;
        }
    }
}
