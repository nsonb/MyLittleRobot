using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactPlayer : MonoBehaviour
{
    // setting is scriptable object
    public AttackStat setting;
    // vision and focus light are objects in the scene that gives view indicator
    public GameObject vision;
    public GameObject focusLight;
    GameObject target;
    private IEnumerator coroutine;

    bool isJumping;

    // event variable
    public delegate void SeePlayer();
    public static event SeePlayer SetAlarm;

    public delegate void LosePlayer();
    public static event LosePlayer StopAlarm;
    Rigidbody rb;

    void Start()
    {
        focusLight.gameObject.SetActive(false);
        coroutine = WatchForPlayer();
        StartCoroutine(coroutine);
        rb = GetComponent<Rigidbody>();
        isJumping = false;
    }

    IEnumerator WatchForPlayer() 
    {
        RaycastHit hit;
        while(true){
            vision.gameObject.SetActive(true);
            for(int i = 0; i<30; i++) {
                Vector3 fwd = transform.TransformDirection(Vector3.forward);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, setting.range)){
                    Debug.DrawRay(transform.position, fwd, Color.red);
                    print("watching");
                    if(hit.transform.gameObject.CompareTag("player")){
                        target = hit.transform.gameObject;
                        print("see player");
                        SetAlarm();
                        yield return StartCoroutine("Alarm");
                        i = 0;
                    }
                }
                yield return new WaitForSeconds(0.1f);
            }
            vision.gameObject.SetActive(false);
            print("Rest");
            yield return new WaitForSeconds(2);
        }    
    }

    IEnumerator Alarm() 
    {   
        vision.gameObject.SetActive(false);
        focusLight.gameObject.SetActive(true);
        for(int i = 0; i<20; i++) {
            print("alarm");
            Jump();
            yield return new WaitForSeconds(setting.time/20);
            LookAtPlayer();
        }
        StopAlarm();
        yield return StartCoroutine("MoveForwardPlayer");
    }

    IEnumerator MoveForwardPlayer() 
    {
        for(int i = 0; i<20; i++) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, setting.step);        
        }
        target = null;
        focusLight.gameObject.SetActive(false);
        yield return null;
    }

    // Enemy behaviors
    void Jump() {
        if(isJumping == false){
            rb.AddForce( setting.enemyJumpForce * transform.up, ForceMode.Impulse);
        }
    }

    // set up so the enemy will look at the player, but only rotate in x and z direction
    void LookAtPlayer() {
        if(target != null) {
            Vector3 lookPosition = target.transform.position - transform.position;
            lookPosition.y = 0;
            transform.rotation = Quaternion.LookRotation(lookPosition);
        }
    }

    // collision to check if enemy is touching ground for jumping
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
