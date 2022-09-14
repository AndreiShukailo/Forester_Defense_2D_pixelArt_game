using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    private void Start()
    {
        _shoots = _playerData.UziShoots;
    }

    public override void Shoot(Transform shootPoint)
    {
        base.Shoot(shootPoint);
        StartCoroutine(BarsOfShoots(shootPoint));
        _isAllowShoot = false;
        _shoots--;
    }

    IEnumerator BarsOfShoots(Transform shootPoint)
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
