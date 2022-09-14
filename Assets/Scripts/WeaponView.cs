using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;

    public Weapon Weapon => _weapon;

    public event UnityAction<Weapon> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    public void UnlockSellButton()
    {
        _sellButton.interactable = true;
    }

    public void LockSellButton()
    {
        _sellButton.interactable = false;
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _lable.text = _weapon.Lable;
        _price.text = _weapon.Price.ToString();
        _icon.sprite = _weapon.Icon;


    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_weapon);
    }
}
