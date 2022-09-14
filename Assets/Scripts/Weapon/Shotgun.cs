using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private void Start()
    {
        _shoots = _playerData.ShotgunShoots;
    }

    public override void Shoot(Transform shootPoint)
    {
        base.Shoot(shootPoint);
        Instantiate(Bullet, shootPoint.position,Quaternion.identity).transform.Rotate(0f,0f,-5f);
        Instantiate(Bullet, shootPoint.position, Quaternion.identity).transform.Rotate(0f, 0f, -2.5f);
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        Instantiate(Bullet, shootPoint.position, Quaternion.identity).transform.Rotate(0f, 0f, 2.5f);
        Instantiate(Bullet, shootPoint.position, Quaternion.identity).transform.Rotate(0f, 0f, 5f);
        _isAllowShoot = false;
        _shoots--;
    }
}
