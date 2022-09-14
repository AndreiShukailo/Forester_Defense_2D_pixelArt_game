using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponHood : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private TMP_Text _shootsText;
    [SerializeField] private Image _weaponIcon;
    [SerializeField] private Slider _reloadBar;

    private void Render()
    {
        if (_player.GetCurrentWeapon().Lable == "Axe")
            _shootsText.gameObject.SetActive(false);
        else
            _shootsText.gameObject.SetActive(true);

        _shootsText.text = _player.GetCurrentWeapon().Shoots.ToString();
        _weaponIcon.sprite = _player.GetCurrentWeapon().Icon;
        _reloadBar.value = (float)_player.GetCurrentWeapon().TimeAfterLastShoot / _player.GetCurrentWeapon().Reloading;
    }

    private void Update()
    {
        Render();
    }
}
