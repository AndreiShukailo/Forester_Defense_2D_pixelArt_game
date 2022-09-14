using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    public void DestroyObject()
    {
        Destroy(_parent);
    }

    public void DeactivateObject()
    {
        _parent.SetActive(false);
    }
}
