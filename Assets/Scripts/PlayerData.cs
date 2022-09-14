using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerData : MonoBehaviour
{
    public int CurrentHealth;
    public int CurrentMoney;

    public Weapon CurrentWeapon;
    public List<Weapon> CurrentWeapons = new List<Weapon>();
    public int PistolShoots;
    public int ShotgunShoots;
    public int UziShoots;
    public int RifleShoots;

    public int CurrentWave;
    public float CurrentVolumeValue;

    public List<Weapon> Weapons;

    public float CurrentTimeAidKit;

    public void Init(int maxHealth)
    {
        CurrentHealth = PlayerPrefs.GetInt("CurrentHealth", maxHealth);
        CurrentMoney = PlayerPrefs.GetInt("CurrentMoney", 0);

        foreach (var item in Weapons)
        {
            if (PlayerPrefs.HasKey(item.Lable))
                CurrentWeapons.Add(item);
        }

        CurrentWeapon = Weapons.Find(p => p.Lable == PlayerPrefs.GetString("CurrentWeapon", "Axe"));

        if (CurrentWeapons.Count == 0)
            CurrentWeapons.Add(CurrentWeapon);

        PistolShoots = PlayerPrefs.GetInt("PistolShoots", 0);
        ShotgunShoots = PlayerPrefs.GetInt("ShotgunShoots", 0);
        UziShoots = PlayerPrefs.GetInt("UziShoots", 0);
        RifleShoots = PlayerPrefs.GetInt("RifleShoots", 0);

        CurrentWave = PlayerPrefs.GetInt("CurrentWave", 0);
        CurrentVolumeValue = PlayerPrefs.GetFloat("CurrentVolumeValue", 1f);

        CurrentTimeAidKit = PlayerPrefs.GetFloat("CurrentTimeAidKit", 0);
    }

    public void LoadPlayerStats(out int currentHealt, out int currentMoney,out Weapon currentWeapon, out List<Weapon> weapons)
    {
        currentHealt = CurrentHealth;
        currentMoney = CurrentMoney;
        currentWeapon = CurrentWeapon;
        weapons = CurrentWeapons;
    }


    public void SavePlayerStats(int currentHealth, int currentMoney, int currentWave, Weapon currentWeapon, List<Weapon> weapons)
    {
        ResetWeapons();

        PlayerPrefs.SetInt("CurrentHealth", currentHealth);
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);

        PlayerPrefs.SetString("CurrentWeapon", currentWeapon.Lable);

        foreach (var item in weapons)
        {
            PlayerPrefs.SetString(item.Lable, item.Lable);
        }

        PlayerPrefs.SetInt("CurrentWave", currentWave);

        SavePistolShoots(Weapons.Find(p => p.Lable == "Pistol").Shoots);
        SaveShotgunShoots(Weapons.Find(p => p.Lable == "Shotgun").Shoots);
        SaveUziShoots(Weapons.Find(p => p.Lable == "Mini Uzi").Shoots);
        SaveRifleShoots(Weapons.Find(p => p.Lable == "Rifle").Shoots);
    }

    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("CurrentHealth");
        PlayerPrefs.DeleteKey("CurrentMoney");
        PlayerPrefs.DeleteKey("CurrentWeapon");

        ResetWeapons();

        PlayerPrefs.DeleteKey("PistolShoots");
        PlayerPrefs.DeleteKey("ShotgunShoots");
        PlayerPrefs.DeleteKey("UziShoots");
        PlayerPrefs.DeleteKey("RifleShoots");
        PlayerPrefs.DeleteKey("CurrentWave");
        PlayerPrefs.DeleteKey("CurrentTimeAidKit");
    }

    private void ResetWeapons()
    {
        foreach (var item in Weapons)
        {
            if (PlayerPrefs.HasKey(item.Lable))
                PlayerPrefs.DeleteKey(item.Lable);
        }
    }

    public void SaveVolumeValue(float currentVolumeValue)
    {
        PlayerPrefs.SetFloat("CurrentVolumeValue", currentVolumeValue);
    }

    public void SaveCurrenTimeAidKit(float currentTimeAifKit)
    {
        PlayerPrefs.SetFloat("CurrentTimeAidKit", currentTimeAifKit);
    }

    public void SavePistolShoots(int shoots)
    {
        PlayerPrefs.SetInt("PistolShoots", shoots);
    }

    public void SaveShotgunShoots(int shoots)
    {
        PlayerPrefs.SetInt("ShotgunShoots", shoots);
    }

    public void SaveUziShoots(int shoots)
    {
        PlayerPrefs.SetInt("UziShoots", shoots);
    }

    public void SaveRifleShoots(int shoots)
    {
        PlayerPrefs.SetInt("RifleShoots", shoots);
    }

    public void SetPlayerMaxHealth(int maxHealth)
    {
        PlayerPrefs.SetInt("CurrentHealth", maxHealth);
    }
}
