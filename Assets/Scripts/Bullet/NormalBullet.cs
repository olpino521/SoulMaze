using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    public override void BulletBehaviour()
    {
        base.BulletBehaviour();
        Rigidbody rig = GetComponent<Rigidbody>();
        rig.velocity = Vector3.zero;
        rig.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

}
