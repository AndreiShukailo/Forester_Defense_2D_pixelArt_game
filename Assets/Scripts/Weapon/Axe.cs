using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    private void Start()
    {
        _shoots = 1;
    }

    public override void Shoot(Transform shootPoint)
    {
        base.Shoot(shootPoint);
        StartCoroutine(DelayShoot(shootPoint));
        _isAllowShoot = false;
    }

    IEnumerator DelayShoot(Transform shootPoint)
    {
         
            yield return new WaitForSeconds(0.5f);
            
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        
    }
}
