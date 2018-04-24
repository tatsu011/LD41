using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour {
    public int Health = 20;
    public int MaxHealth = 20;

    public int Score;

    private void Awake()
    {
        Health = MaxHealth;
    }


    void TakeDamage(GameObject bullet)
    {
        Health -= bullet.GetComponent<Bullet>().DamageAmount;
        Debug.Log($"took {bullet.GetComponent<Bullet>().DamageAmount} damage, now at {Health}");
        AudioSource audio = GetComponent<AudioSource>();
        if(audio == null)
        {
            Debug.Log("This object does not have a hit source.");
        }
        
        bullet.SendMessage("PostDamageApplied", SendMessageOptions.DontRequireReceiver);
        if(Health <=0)
        {
            //add to Score object.

            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        gameObject.SetActive(false);
    }
}
