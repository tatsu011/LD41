using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour {
    public int Health = 20;

    void TakeDamage(GameObject bullet)
    {
        Health -= bullet.GetComponent<Bullet>().DamageAmount;
        Debug.Log($"took {bullet.GetComponent<Bullet>().DamageAmount} damage, now at {Health}");
        bullet.SendMessage("PostDamageApplied", SendMessageOptions.DontRequireReceiver);
        if(Health <=0)
        {
            //add to Score object.

            gameObject.SetActive(false);
        }
    }
}
