using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    //Variables
    Slider _healthSlider;


    //Methods  for  setting max health and normal health

    public void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }
    public void SetMaxHealth(int maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
    }


    public void SetHealth(int health)
    {    
        _healthSlider.value = health;
    }

}
