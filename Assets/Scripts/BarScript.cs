using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{


    public Slider slider;
    
    private int health;
    
    
    public void SetHealth(int health)
    {
        slider.value = health;
        slider.maxValue = FindObjectOfType<QteManager>().maxHealth;
    }

    
}
