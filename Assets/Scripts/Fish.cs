using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : DamageableObject {

    public int FireTimer;
    
    public int DespawnTimer;
    public bool Dead = false;
    public float Speed = 2.0f;

    public string FishName;

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
        else if(!WasDeadPreviously)
        {
            WasDeadPreviously = true;
            foreach(Collider2D c2d in GetComponents<Collider2D>())
            {
                c2d.enabled = false;
                
            }

        }

        if(DespawnTimer <= 0)
        {
            gameObject.SetActive(false);
        }

        DespawnTimer--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("I spy a player object.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("I hit a player object.");
        }
    }
}
