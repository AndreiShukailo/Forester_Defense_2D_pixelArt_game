using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private PlayerData _playerData;

    private void Awake()
    {
        _slider.value = _playerData.CurrentVolumeValue;
    }

    public void ChangeVolume()
    {
        if (_slider.value == 0)
            _audioMixer.audioMixer.SetFloat("MasterVolume", -80f);
        else
            _audioMixer.audioMixer.SetFloat("MasterVolume", 20*Mathf.Log10((Mathf.Lerp(1/10000, 1, _slider.value))));

        _playerData.SaveVolumeValue(_slider.value);
    }
}
