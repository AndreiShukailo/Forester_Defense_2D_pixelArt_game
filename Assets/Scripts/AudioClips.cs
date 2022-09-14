using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AudioClips", menuName = "AidioClips/Create new audioClips")]
public class AudioClips : ScriptableObject
{
    [SerializeField] private List<AudioClip> _audioClips;

    public List<AudioClip> AudioClipsList => _audioClips;
}
