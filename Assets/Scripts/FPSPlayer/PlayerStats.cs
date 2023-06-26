using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    static float Health;
    static float MaxHealth= 100000;

    public Slider HealthBar;

    private void Start(){
        HealthBar.minValue= 0;
        HealthBar.maxValue= MaxHealth;
        Health= MaxHealth;
    }

    private void Update(){
        HealthBar.value= Health;
        if(HealthBar.value<=0){
            Die();
        }
    }

    public static void Damage(float amount){
        Health= Health- amount;
    }

    void Die(){
        Destroy(gameObject);
    }
   
}
