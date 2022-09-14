using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _lable;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _reloading;   

    [SerializeField] private string _idleAnimation;
    [SerializeField] private string _shootAnimation;
 
    [SerializeField] protected Bullet Bullet;

    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private string _ShootAudioName;

    [SerializeField] protected PlayerData _playerData;

    private AudioSource _audioSource;
    private float _timeAfterLastShoot;

    protected int _shoots;
    protected bool _isAllowShoot = true;

    public string Lable => _lable;
    public int Price => _price;
    public Sprite Icon => _icon;
    public string IdleAnimation => _idleAnimation;
    public string ShootAnimation => _shootAnimation;
    public bool IsAllowShoot => _isAllowShoot;
    public float Reloading => _reloading;
    public int Shoots => _shoots;
    public float TimeAfterLastShoot => _timeAfterLastShoot;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public virtual void Shoot(Transform shootPoint) 
    {
        _audioManager.PlaySound(_audioSource, _ShootAudioName);
    }

    public void StopPlayAudio()
    {
        _audioSource.Stop();
    }

    public void Buy()
    {
        _shoots += 10;
    }

    public void SetAllowShoot(bool isAllow)
    {
        _isAllowShoot = isAllow;
    }

    public void SetTimeAfterLastShoot(float time)
    {
        _timeAfterLastShoot = time;
    }

    public void IncreaseTimeAfterLastShoot(float time)
    {
        _timeAfterLastShoot += time;
    }
}
