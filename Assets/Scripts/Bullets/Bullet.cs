using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _distanse;
    [SerializeField] protected float _delay;

    protected Vector3 _startPosition;
    protected float _currentTime;

    private void OnEnable()
    {
        _currentTime = 0;
        _startPosition = transform.position;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (Vector3.Distance(_startPosition, transform.position) < _distanse)
        {
            if (_currentTime >= _delay)
            {
                MooveBullet();
            }
        }
        else
            Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);

            Destroy(gameObject);
        }
    }

    protected virtual void MooveBullet()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
