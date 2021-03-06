﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int MaxHealth = 3;
    public int CurrentHealth = 3;

    public bool IsInvincible = false;
    int IVTimer = 30;
    int IVTime = 0;
    public int HeldScore;


    public Vector2 MaximumSpeed = new Vector2(1.0f, 1.0f);
    public Vector2 ShiftedSpeed = new Vector2(2.0f, 2.0f);
    

    void Start()
    {

    }

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity = new Vector2
            {
                x = Input.GetAxis("Horizontal") * ShiftedSpeed.x,
                y = Input.GetAxis("Vertical") * ShiftedSpeed.y
            };
        }
            else
        {
            velocity = new Vector2
            {
                x = Input.GetAxis("Horizontal") * MaximumSpeed.x,
                y = Input.GetAxis("Vertical") * MaximumSpeed.y
            };
        }

        rb.velocity = velocity;
    }



    public void OnBaitCollided(GameObject other)
    {

    }

    void FishContact(GameObject fish)
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = fish.GetComponent<SpriteRenderer>().sprite;
        CatchOfTheDay.Instance.CaughtFish = fish.GetComponent<Fish>().FishName;
        HeldScore = fish.GetComponent<Fish>().CatchScore;
    }


}