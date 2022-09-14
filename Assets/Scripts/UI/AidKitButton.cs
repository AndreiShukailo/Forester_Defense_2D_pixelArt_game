using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AidKitButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private AidKit _aidKit;
    [SerializeField] private Player _player;
    [SerializeField] private float _reloadTime;
    [SerializeField] private PlayerData _playerData;

    private float _currenTime;
    private Button _button;

    public float CurrentTime => _currenTime;

    private void Awake()
    {
        InitButton();
        _button = GetComponent<Button>();

        SetIntarectible(_player.Money);   
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(_player.Heal);
        _button.onClick.AddListener(SetCurentTimeZero);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_player.Heal);
        _button.onClick.RemoveListener(SetCurentTimeZero);
    }

    private void Start()
    {
        _currenTime = _playerData.CurrentTimeAidKit;
    }

    private void Update()
    {
        if (_currenTime < _reloadTime)
        {
            _button.interactable = false;
            _button.image.fillAmount = _currenTime / _reloadTime;
            _currenTime += Time.deltaTime;
        }
        else
        {
            SetIntarectible(_player.Money);
            _button.image.fillAmount = 1f;
        }
            
    }

    private void SetIntarectible(int money)
    {
        if (money >= _aidKit.Price)
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    private void InitButton()
    {
        _priceText.text = _aidKit.Price.ToString();
    }

    private void SetCurentTimeZero()
    {
        _currenTime = 0;
    }
}
