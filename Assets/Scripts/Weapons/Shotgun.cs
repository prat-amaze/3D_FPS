using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shotgun : MonoBehaviour
{
    public GameObject shotgun1;
    private bool isFiring= false;
    //public GameObject muzzleFlash;
    public AudioSource shotgunShot;
    private float toTarget;
    public Camera fpsCam;
    public AudioSource shotgunReload;

    public float damage= 250f;
    public float range= 50f;
    
    public TextMeshProUGUI ammoTextUI;
    public static int pistolCount;
    public int maxAmmo= 1;
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
                pistolCount -=1;
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
        shotgun1.GetComponent<Animator>().Play("FireShotgun");
        shotgunShot.Play();
        //muzzleFlash.SetActive(true);
        //yield return new WaitForSeconds(0.03f);
        //muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        shotgun1.GetComponent<Animator>().Play("New State");
        isFiring= false;
    }

    IEnumerator Reload(){
        isReloading = true;
        shotgunReload.Play();

        animator.SetBool("Reloading", true);

        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        pistolCount= maxAmmo;

        animator.SetBool("Reloading", false);

        isReloading= false;
    }
}