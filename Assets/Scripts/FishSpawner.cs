using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {
    public bool Active;
    public int Delay = 30;
    public int spawnerTimer = 60;
    public int FishActiveTimer = 120;
    public float SpawnRadius;
    public bool GoingRight = false;
    int ActiveTimer;

    private void Start()
    {
        if(Active)
            ActiveTimer = spawnerTimer + Delay;
    }

    private void Update()
    {
        if(ActiveTimer <=0)
        {
            //theoretically < 0 shouldn't happen, but cover any sneaky sneaks.
            Pool pool = GetComponent<Pool>();
            GameObject fish = pool.GetPooledObject();
            fish.SetActive(true);
            fish.transform.position = new Vector3(transform.position.x + (Random.value * 2 - 1) * SpawnRadius, 
                                                  transform.position.y + (Random.value * 2 - 1) * SpawnRadius, 
                                                  transform.position.z);
            fish.GetComponent<Fish>().WakeUp(FishActiveTimer);
            ActiveTimer = spawnerTimer;


        }


        ActiveTimer--;
    }

}
