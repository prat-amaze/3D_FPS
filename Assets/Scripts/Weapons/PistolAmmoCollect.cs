using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmoCollect : MonoBehaviour
{
    public AudioSource ammoCollect;

    void OnTriggerEnter(Collider other){       
        ammoCollect.Play();
        AmmoDisplay.pistolCount += 30;
        this.gameObject.SetActive(false);
    }
}
