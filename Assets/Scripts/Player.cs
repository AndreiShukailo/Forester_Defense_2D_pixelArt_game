using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Menu _menu;
    [SerializeField] private HealthEffect _healthEffect;
    [SerializeField] private AidKit _aidKit;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Spawner _spawner;

    [SerializeField] private PlayerData _playerData;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber;
    private int _currentHealth;

    private AudioSource _audioSource;
    private string _changeWeaponSound = "ChangeWeapon";

    private Animator _animator;

    private int _money;

    public int Money
    {
        get
        {
            return _money;
        }
        private set
        {
            _money = value;
        }
    }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Awake()
    {
        _playerData.Init(_health);
    }

    private void OnEnable()
    {
        _playerInput.ScreenClick += OnScreenClick;
        _spawner.OnNextWave += SavePlayerStats;
    }

    private void OnDisable()
    {
        _playerInput.ScreenClick -= OnScreenClick;
        _spawner.OnNextWave -= SavePlayerStats;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _animator = GetComponent<Animator>();

        _playerData.LoadPlayerStats(out _currentHealth, out _money, out  _currentWeapon, out _weapons);

        HealthChanged?.Invoke(_currentHealth, _health);

        ChangeWeapon(_currentWeapon);

        _currentWeaponNumber = _weapons.IndexOf(_currentWeapon);

        _currentWeapon.SetTimeAfterLastShoot(_currentWeapon.Reloading);
    }

    private void Update()
    {
        _currentWeapon.IncreaseTimeAfterLastShoot(Time.deltaTime);

        if (_currentWeapon.TimeAfterLastShoot >= _currentWeapon.Reloading)
            _currentWeapon.SetAllowShoot(true);
    }

    private void SetIdleAnimation(Weapon weapon)
    {
        _animator.Play(weapon.IdleAnimation);
    }

    public void ApplayDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
        _menu.OpenDeathScreen();
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    private void AddWeapon(Weapon weapon)
    {
        if (_weapons.Contains(weapon))
        {
            ChangeWeapon(weapon);
            return;
        }
        else
        {
            _weapons.Add(weapon);
            ChangeWeapon(weapon);
            _currentWeaponNumber++;
        }
            
            
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);

        weapon.Buy();

        AddWeapon(weapon);
    }

    private void RemoveCurrenWeapon(Weapon weapon)
    {
        NextWeaponWithSound();

        _weapons.Remove(weapon);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1 || _currentWeaponNumber > _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        _currentWeapon.StopPlayAudio();

        ChangeWeapon(_weapons[_currentWeaponNumber]);

        _audioManager.PlaySound(_audioSource, _changeWeaponSound);
    }

    private void NextWeaponWithSound()
    {
        if (_currentWeaponNumber == _weapons.Count - 1 || _currentWeaponNumber > _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        _currentWeapon.StopPlayAudio();

        ChangeWeapon(_weapons[_currentWeaponNumber]);

        _audioManager.PlaySound(_audioSource, _changeWeaponSound);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;

        SetIdleAnimation(weapon);
    }

    private void OnScreenClick()
    {
        if (_currentWeapon.IsAllowShoot)
        {
            _currentWeapon.Shoot(_shootPoint);
            _animator.Play(_currentWeapon.ShootAnimation);
            _currentWeapon.SetTimeAfterLastShoot(0);

            if (_currentWeapon.Shoots <= 0)
                RemoveCurrenWeapon(_currentWeapon);        
        }

    }

    public Weapon GetCurrentWeapon()
    {
        return _currentWeapon;
    }

    public void Heal()
    {
        Money -= _aidKit.Price;
        MoneyChanged?.Invoke(Money);
        AddHealth();

        HealthChanged?.Invoke(_currentHealth, _health);
        _healthEffect.Play();
    }

    public void AddHealth()
    {
        if (_health - _currentHealth >= _aidKit.HealHealth)
            _currentHealth += _aidKit.HealHealth;
        else
            _currentHealth = _health;
    }

    private void SavePlayerStats(int waveIndex)
    {
        _playerData.SavePlayerStats(_currentHealth, _money, waveIndex, _currentWeapon, _weapons);
    }
}