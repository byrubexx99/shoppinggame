using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Slider HealthSlider;  
   
    void Start()
    {
        HealthSlider.value = 100;
    }
    
    public void QuitHealth(float damage)
    {
        HealthSlider.value -= damage;
    }

    public void Heal(float life)
    { 
        if (HealthSlider.value <=100) HealthSlider.value += life;
    }
}
