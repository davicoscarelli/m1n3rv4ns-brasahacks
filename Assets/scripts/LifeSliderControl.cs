using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSliderControl : MonoBehaviour 
{ 
    private TapController scriptTapController;
    public Slider LifeSlider;

    void Start()
    {
        scriptTapController = GameObject.FindWithTag("Player").GetComponent<TapController>();
        LifeSlider.maxValue = scriptTapController.life;
        UpdateLifeSlider();
    }

    public void UpdateLifeSlider()
    {
        LifeSlider.value = scriptTapController.life;
    }
}