using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class SounController : MonoBehaviour
{ 
    private Camera _camera;

    [SerializeField] public Slider slider;
    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        _camera.GetComponent<AudioSource>().volume = slider.value;
    }
}
