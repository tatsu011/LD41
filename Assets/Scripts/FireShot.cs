using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour {

    public int Delay;
    public float BulletSpeed;
    public float DownwardOffset = 0;
    public int BulletDamage = 1;
    int Tick = 0;

    public void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            OnFireKey();
        }
        Tick++;
    }

    void OnFireKey()
    {
        if(Tick >= Delay)
        {
            Tick = 0;
            GameObject bullet = GetComponent<Pool>().GetPooledObject();
            bullet.SetActive(true);
            bullet.transform.position = transform.position + new Vector3(0,-DownwardOffset, 0);
            bullet.GetComponent<Bullet>().DamageAmount = BulletDamage;
            bullet.GetComponent<Bullet>().SetRay(270.0f, BulletSpeed);
            
            AudioSource sound = GetComponent<AudioSource>();
            if(sound.isPlaying)
            {
                sound.Stop();
                sound.Play();
            }
            else
            {
                sound.Play();
            }
        }
    }
}
