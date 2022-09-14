using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private TakeDamageTextController _takeDamageTextController;

    private CoinSpawner _coinSpawner;
    private SpriteRenderer _spriteRenderer;
    private Player _target;
    private int _maxHealt;
    private Color _targetColor = new Color(1,0,0);
    private Color _startColor;

    public int Health => _health;
    public int Reward => _reward;
    public Player Target => _target;

    public event UnityAction<Enemy> Dying;
    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startColor = _spriteRenderer.color;
    }

    public void Init(Player target, CoinSpawner coinSpawner)
    {
        _maxHealt = _health;
        _target = target;
        _coinSpawner = coinSpawner;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        HealthChanged?.Invoke(_health, _maxHealt);

        _takeDamageTextController.CreateTextDamage(damage);

        StartCoroutine(TakeDamageAnimation());

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            _coinSpawner.SpawnCoin(transform.position);
            Destroy(gameObject);
        }
    }

    private IEnumerator TakeDamageAnimation()
    {
        _spriteRenderer.color = _targetColor;

        yield return new WaitForSeconds(0.1f);

        _spriteRenderer.color = _startColor;
    }
}
