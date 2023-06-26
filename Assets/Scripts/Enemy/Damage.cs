using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float health= 250f;

    public void TakeDamage(float amount){
        health -= amount;
        if(health<= 0f){
            this.GetComponent<Animator>().Play("death");
            Die();
        }
    }

    void Die(){
        //this.GetComponent<Animator>().Play("Death");
        Destroy(gameObject);
    }
}
