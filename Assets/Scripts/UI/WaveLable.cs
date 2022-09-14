using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveLable : MonoBehaviour
{
    [SerializeField] private TMP_Text _waveNumber;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.OnWaveChange += SetWaveNumber;
    }

    private void OnDisable()
    {
        _spawner.OnWaveChange -= SetWaveNumber;
    }

    private void SetWaveNumber(int waveNuber)
    {
        _waveNumber.text = waveNuber.ToString();
    }
}
