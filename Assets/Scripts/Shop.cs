using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private List<WeaponView> _views = new List<WeaponView>();

    private void Awake()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void OnEnable()
    {
        foreach (var view in _views)
        {
            view.UnlockSellButton();
            view.SellButtonClick += OnSellButtonClick;
            TryLockItem(view.Weapon, view);
        }
    }

    private void OnDisable()
    {
        foreach (var view in _views)
        {
            view.SellButtonClick -= OnSellButtonClick;
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        _views.Add(view);
        view.Render(weapon);

        TryLockItem(weapon, view);
    }

    private void OnSellButtonClick(Weapon weapon)
    {
        TrySellWeapon(weapon);
    }

    private void TrySellWeapon(Weapon weapon)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);

            foreach (var item in _views)
            {
                TryLockItem(item.Weapon, item);
            }
        }
    }

    private void TryLockItem(Weapon weapon, WeaponView view)
    {
        if (weapon.Price > _player.Money)
            view.LockSellButton();
    }
}
