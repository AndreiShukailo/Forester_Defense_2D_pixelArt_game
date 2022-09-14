using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private int _count;

    private List<GameObject> _pool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            GameObject obj = Instantiate(_gameObject, this.transform);
            obj.SetActive(false);
            _pool.Add(obj);
        }
    }

    protected GameObject TryGetObject(Vector3 spawnPoint)
    {
        GameObject obj = _pool.First(p=> p.activeSelf == false);

        obj.transform.position = spawnPoint;
        obj.SetActive(true);
        return obj;
    }
}
