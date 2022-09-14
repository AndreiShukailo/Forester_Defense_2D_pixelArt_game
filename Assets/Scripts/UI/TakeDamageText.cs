using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TakeDamageText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Init(int damage)
    {
        _text.text = $"-{damage.ToString()}";
    }
}
