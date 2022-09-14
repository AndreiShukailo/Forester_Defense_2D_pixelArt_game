using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PlayerInput : MonoBehaviour, IPointerDownHandler
{
    public event UnityAction ScreenClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == 0)
            ScreenClick?.Invoke();    
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
