using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Bullet bullet;
    public GameObject shootPoint;
    public float speed = 20f;
    public float maxLifeTime = 2.0f;
    public int maxNumberOfBullets = 3;
    List<Bullet> bullets = new List<Bullet>();
    public List<GameObject> hps;
    // Update is called once per frame
    private void Start() {
        Bullet instance;
        instance = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        bullets.Add(instance);
        instance.Disable();
        instance = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        bullets.Add(instance);
        instance.Disable();
        instance = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        bullets.Add(instance);
        instance.Disable();
    }
    void Update()
    {   
        CheckBullet();
        if(Input.GetKeyDown("e"))
        {
            ShootAvailBullet();
        }
    }

    // check if bullets in list have exceed their given lifetime, if so, disable and reset them
    void CheckBullet() {
        for(int x =0; x < bullets.Count ; x++) {
            if(bullets[x].GetLifeTime() >= maxLifeTime || bullets[x].CheckTouch()) {
                bullets[x].Disable();
                hps[x].SetActive(true);
            }
        }
    }

    // check if any bullet is available to be shot, then return that bullet
    void ShootAvailBullet(){
        
        for(int x = 0; x < bullets.Count; x++){
            if(bullets[x].CheckShoot() == false) {
                bullets[x].Enable();
                bullets[x].Shoot(shootPoint.transform, shootPoint.transform.forward*speed);
                hps[x].SetActive(false);
                return;
            }
        }
        return;
    }
}
