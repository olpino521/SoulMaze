using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected float despawnTime;

    public virtual void BulletBehaviour()
    {
        //corutine to despawn
        StartCoroutine(DespawnBullet());
    }

    public virtual void OnCollisionDetection(Collision col)
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        BulletBehaviour();
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionDetection(collision);
    }

    IEnumerator DespawnBullet()
    {
        yield return new WaitForSeconds(despawnTime);
        gameObject.SetActive(false);
    }
}
