using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : Bullet
{
    protected override void MooveBullet()
    {
        transform.Translate(-transform.right * _speed * Time.deltaTime);
    }
}
