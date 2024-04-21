using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSize : MonoBehaviour
{
    [SerializeField] private Vector3 newSize;
    [SerializeField] private Vector3 standartSize;
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = newSize;
    }
}
