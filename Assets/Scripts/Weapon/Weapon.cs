using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string name;
    public float fireRate;
    public int bulletSlot;
    public Transform bulletExit;

    float lastUpdate;
    ObjectPooler pooler;
    float bulletsPerSecond;
    private void Start()
    {
        pooler = ObjectPooler.SharedInstance;
        
    }

    public void Fire()
    {
        bulletsPerSecond = 1 / fireRate;
        if (Time.time - bulletsPerSecond >= lastUpdate)
        {
            SpawnBullet();
            lastUpdate = Time.time;
        }
        
    }

    public virtual void SpawnBullet()
    {
        if (pooler == null) 
            pooler = ObjectPooler.SharedInstance;

        GameObject tempBullet = pooler.GetPooledObject(bulletSlot);
        tempBullet.transform.position = bulletExit.position;
        tempBullet.transform.rotation = bulletExit.rotation;
        tempBullet.SetActive(true);
        //Spawn bullet from current weapon exit and correct bullet type
    }

}
