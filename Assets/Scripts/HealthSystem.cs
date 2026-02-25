using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Slider healthSlider;  
   
    void Start()
    {
        healthSlider.value = 100;
    }
    
    public void QuitHealth(float damage)
    {
        healthSlider.value -= damage;
    }

    public void Heal(float life)
    { 
        if (healthSlider.value <=100) healthSlider.value += life;
    }
}
