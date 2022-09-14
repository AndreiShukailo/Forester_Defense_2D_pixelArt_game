using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPref;

    public void SpawnCoin(Vector3 position)
    {
        Instantiate(_coinPref, position, Quaternion.identity);
    }
}
