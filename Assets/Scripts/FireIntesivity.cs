using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireIntesivity : MonoBehaviour
{
    private Light _light;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _light = GetComponent<Light>();
    }
    private void Update()
    {
        _light.intensity = _slider.value;
    }

}
