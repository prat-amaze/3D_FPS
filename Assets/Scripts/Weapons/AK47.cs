using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AK47 : MonoBehaviour
{
    public GameObject AK;
    private bool isFiring= false;
    //public GameObject muzzleFlash;
    public AudioSource AKShot;
    private float toTarget;
    public Camera fpsCam;
    public AudioSource AKreload;

    public float damage= 150f;
    public float range= 200f;

    public TextMeshProUGUI ammoTextUI;
    public static int pistolCount;
    public int maxAmmo= 45;
    private bool isReloading= false;
    public float reloadTime= 2f;

    public Animator animator;

    void Start(){
        pistolCount= maxAmmo;
    }
    

    void Update()
    {
        if(isReloading){
            return;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            if(isFiring== false)
            {
                StartCoroutine(FireShotgun());
                pistolCount -=4;
            }
        }
        ammoTextUI.text= "AMMO: " + pistolCount;

        if(pistolCount <=0 ){
            StartCoroutine(Reload());
            return;
        }
    }

    IEnumerator FireShotgun()
    {
        isFiring= true;
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Target target= hit.transform.GetComponent<Target>();
            if(target != null){
                target.TakeDamage(damage);
            }

            Damage zombie= hit.transform.GetComponent<Damage>();
            if(zombie != null){
                zombie.TakeDamage(damage);
            }
            
        }
        AK.GetComponent<Animator>().Play("FireAK");
        AKShot.Play();
        //muzzleFlash.SetActive(true);
        //yield return new WaitForSeconds(0.03f);
        //muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        AK.GetComponent<Animator>().Play("New State");
        isFiring= false;
    }

    IEnumerator Reload(){
        isReloading = true;
        AKreload.Play();

        animator.SetBool("Reloading", true);

        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        pistolCount= maxAmmo;

        animator.SetBool("Reloading", false);

        isReloading= false;
    }
}
