using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageTextController : ObjectPool
{
    [SerializeField] private Transform _spawnPoint;

    public void CreateTextDamage(int damage)
    {
        Vector3 spawnPoint = new Vector3(_spawnPoint.position.x, Random.Range(_spawnPoint.position.y - 0.5f, _spawnPoint.position.y + 0.5f), _spawnPoint.position.z);
        GameObject obg = TryGetObject(spawnPoint);
        obg.TryGetComponent(out TakeDamageText takeDamageText);
        takeDamageText.Init(damage);
    }
}
