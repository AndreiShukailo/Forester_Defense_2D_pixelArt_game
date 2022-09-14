using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClips _audioClips;
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private PlayerData _playerData;

    private void Start()
    {
        ChangeVolume(_playerData.CurrentVolumeValue);
    }

    public void PlaySound(AudioSource audioSourse, string AudioName)
    {
        audioSourse.PlayOneShot(_audioClips.AudioClipsList.Find(p => p.name == AudioName));
    }

    private void ChangeVolume(float volume)
    {
        if (volume == 0)
            _audioMixer.audioMixer.SetFloat("MasterVolume", -80f);
        else
            _audioMixer.audioMixer.SetFloat("MasterVolume", 20 * Mathf.Log10((Mathf.Lerp(1 / 10000, 1, volume))));

        _audioMixer.audioMixer.GetFloat("MasterVolume", out float value);
    }
}
