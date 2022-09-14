using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    private void Start()
    {
        _shoots = _playerData.PistolShoots;
    }

    public override void Shoot(Transform shootPoint)
    {
        base.Shoot(shootPoint);
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        _isAllowShoot = false;
        _shoots--;
    }
}
