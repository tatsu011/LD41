using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int DamageAmount;

    int ExpireTick = 200;
    int tickAmount = 0;

    private void Update()
    {
        if (tickAmount <= 0)
            gameObject.SetActive(false);

        tickAmount--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    public void PostDamageApplied()
    {
        gameObject.SetActive(false);
    }

    public void SetRay(Vector2 direction, float Speed)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * Speed);
        tickAmount = ExpireTick;
    }

    public void SetRay(float angle, float Speed) //angle is in radians.
    {
        //convert degrees to radians.
        float rad = angle * Mathf.PI / 180; 
        SetRay(new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)), Speed);
    }
}
