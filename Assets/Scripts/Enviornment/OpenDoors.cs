using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public float theDistance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject leftDoor;
    public GameObject rightDoor; 
    public AudioSource Doors;
    
    void Update()
    {
        theDistance= PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver(){
        if(theDistance<= 2.5){
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
            if(Input.GetButtonDown("Action")){
                Doors.Play();
                this.GetComponent<BoxCollider>().enabled= false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                leftDoor.GetComponent<Animator>().Play("Left_door");
                rightDoor.GetComponent<Animator>().Play("Right_door");
            }
        }
    }

    void OnMouseExit(){
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
        
    }
}
