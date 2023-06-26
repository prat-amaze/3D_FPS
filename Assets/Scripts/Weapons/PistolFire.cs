using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PistolFire : MonoBehaviour
{
    public GameObject BlackPistol;
    private bool isFiring= false;
    public GameObject muzzleFlash;
    public AudioSource pistolShot;
    private float toTarget;
    public Camera fpsCam;
    public AudioSource pistolReload;

    public float damage= 100f;
    public float range= 100f;

    public TextMeshProUGUI ammoTextUI;
    public static int pistolCount;
    public int maxAmmo= 10;
    private bool isReloading= false;
    public float reloadTime= 1f;

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
                StartCoroutine(FireThePistol());
                pistolCount -=1;
            }
        }
        ammoTextUI.text= "AMMO: " + pistolCount;

        if(pistolCount <=0 ){
            StartCoroutine(Reload());
            return;
        }
    }

    IEnumerator FireThePistol()
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
        BlackPistol.GetComponent<Animator>().Play("FirePistol");
        pistolShot.Play();
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.03f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.23f);
        BlackPistol.GetComponent<Animator>().Play("New State");
        isFiring= false;
    }

    IEnumerator Reload(){
        isReloading = true;
        pistolReload.Play();

        animator.SetBool("Reloading", true);

        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);
        
        pistolCount= maxAmmo;
        isReloading= false;
    }
}
