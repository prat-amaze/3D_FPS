using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{

    public TextMeshProUGUI ammoTextUI;
    public static int pistolCount;

    public int maxAmmo= 10;
    private bool isReloading= false;
    public float reloadTime= 1f;

    void Start(){
        pistolCount= maxAmmo;
    }

    void Update()
    {
        if(isReloading){
            return;
        }

        if(Input.GetButtonDown("Fire1")){
            pistolCount -=1;
        }

        ammoTextUI.text= "AMMO: " + pistolCount;

        if(pistolCount <=0 ){
            StartCoroutine(Reload());
            return;
        }
    }

    IEnumerator Reload(){
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        pistolCount= maxAmmo;
        isReloading= false;
    }
}
