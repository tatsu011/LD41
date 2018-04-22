using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : DamageableObject {

    public int FireTimer;
    
    public int DespawnTimer;
    public bool Dead = false;
    public float Speed = 2.0f;

    bool WasDeadPreviously = false;

    
    void OnFishDied()
    {
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
    }

    internal void WakeUp(int fishActiveTimer)
    {
        DespawnTimer = fishActiveTimer;
        gameObject.SetActive(true);
        if(Dead)
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
    }

    private void Update()
    {
        if(!Dead)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * Speed);
        }
        if(DespawnTimer <= 0)
        {
            gameObject.SetActive(false);
        }



        DespawnTimer--;
    }
}
