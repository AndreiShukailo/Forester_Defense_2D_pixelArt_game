using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private Menu _menu;
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private string _newWaveSound;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private AidKitButton _aidKitButton;

    private AudioSource _audioSource;

    private Wave _currentWave;
    private int _currentWaveNumber;

    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int,int> EnemyCountChanged;
    public event UnityAction<int> OnNextWave;
    public event UnityAction<int> OnWaveChange;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _currentWaveNumber = _playerData.CurrentWave;
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {

        if (_currentWave == null)
        {
            if (_waves.Count <= _currentWaveNumber + 1)
                TryOpenVictoryScreen();

            return;
        }   

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Dely)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;

            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Templates[Random.Range(0,_currentWave.Templates.Count)], _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player, _coinSpawner);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
        OnWaveChange?.Invoke(_currentWaveNumber + 1);
        _audioManager.PlaySound(_audioSource, _newWaveSound);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _player.AddMoney(enemy.Reward);
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;

        OnNextWave?.Invoke(_currentWaveNumber);
        _playerData.SaveCurrenTimeAidKit(_aidKitButton.CurrentTime);
    }

    private void TryOpenVictoryScreen()
    {
        if (transform.childCount == 0)
            _menu.OpenVictoryScreen();         
    }
}

[System.Serializable]
public class Wave
{
    public List<GameObject> Templates;
    public float Dely;
    public int Count;
}
