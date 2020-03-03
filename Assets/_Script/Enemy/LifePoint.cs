using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoint : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> hitpoints;
    int hp = 3;
    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Bullet")){
            
            hp--;
            switch(hp) {
                case 2:
                    print("2hp");
                    hitpoints[0].transform.gameObject.SetActive(false);
                    break;
                case 1:
                    print("1hp");
                    hitpoints[1].transform.gameObject.SetActive(false);
                    break;
                case 0:
                    print("0hp");
                    transform.gameObject.SetActive(false);
                    break;
            }
        }
    }
}
