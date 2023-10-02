using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Sensitivity");
    }
    public void OnValueChanged(float newValue)
    {
        PlayerPrefs.SetFloat("Sensitivity", newValue);
    }
}
