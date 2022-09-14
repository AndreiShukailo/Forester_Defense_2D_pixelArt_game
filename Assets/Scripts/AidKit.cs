using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField] private int _healHealth;
    [SerializeField] private int _price;

    public int HealHealth => _healHealth;
    public int Price => _price;

}
