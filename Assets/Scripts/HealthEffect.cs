using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEffect : MonoBehaviour
{
    [SerializeField] private GameObject _aidKit;
    [SerializeField] private SpriteRenderer _target;
    [SerializeField] private Color _targetColor;

    private Color _startcolor;

    private void Start()
    {
        _startcolor = _target.color;
    }

    public void Play()
    {
        StartCoroutine(AidKitAnimation());
    }

    private IEnumerator AidKitAnimation()
    {
        _target.color = _targetColor;
        _aidKit.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        _target.color = _startcolor;
    }
}

