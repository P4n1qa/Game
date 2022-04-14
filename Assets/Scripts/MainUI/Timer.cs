using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timeStart = 0f;
    private TextMeshProUGUI _timer;

    private void Start()
    {
        _timer = GetComponent<TextMeshProUGUI>();
        _timer.text = _timeStart.ToString();
    }

    private void Update()
    {
        _timeStart += Time.deltaTime;
        _timer.text = Mathf.Round(_timeStart).ToString();
    }
}
