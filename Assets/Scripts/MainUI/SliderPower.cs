using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPower : MonoBehaviour
{
    [SerializeField] private float _power;
        
    public Slider Slider;

    private void Start()
    {
        StartCoroutine(CR_PlusPower());
    }

    private IEnumerator CR_PlusPower()
    {
        while (Slider.value < Slider.maxValue)
        {
            Slider.value += _power * Time.deltaTime;
            yield return 0;
        }
        yield return new WaitUntil(predicate: () => Slider.value == Slider.maxValue);
        StartCoroutine(CR_MinusPower());
    }
    private IEnumerator CR_MinusPower()
    {
        while (Slider.value > Slider.minValue)
        {
            Slider.value -= _power * Time.deltaTime;
            yield return null;
        }
        yield return new WaitUntil(predicate:() => Slider.value==Slider.minValue);
        StartCoroutine(CR_PlusPower());
    }
}
