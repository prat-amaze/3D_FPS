using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class S_Alien : MonoBehaviour
{
    private NavMeshAgent agent= null;
    [SerializeField] private Transform target;
    [SerializeField] private float stoppingDistance = 3;
    private Animator anim= null;
    public float damage= 10;

    private void Start(){
        GetReferences();
    }

    private void Update(){
        MoveToTarget();

        float distanceToTarget= Vector3.Distance(transform.position, target.position);
        if(distanceToTarget<= stoppingDistance){
            anim.SetFloat("Speed", 0f);
        }
    }

    private void MoveToTarget(){
        float distanceToTarget= Vector3.Distance(transform.position, target.position);

        if(distanceToTarget <= 20){
            agent.SetDestination(target.position);
            anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        }

        if(distanceToTarget <= stoppingDistance){
            this.GetComponent<Animator>().Play("Attack");
            RotateToTarget();
            PlayerStats.Damage(damage);
        }
    }
    
    private void GetReferences(){
        agent= GetComponent<NavMeshAgent>();
        anim= GetComponent<Animator>();
    }

    private void RotateToTarget(){
        transform.LookAt(target);
    }
}