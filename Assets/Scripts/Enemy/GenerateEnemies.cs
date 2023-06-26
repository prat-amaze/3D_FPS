using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int waveNo= 1;
    
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator EnemyDrop(){
        while(waveNo< 1000){
            enemyCount=0;
            while (enemyCount < 3)
            {
                xPos= Random.Range(-8,10);
                zPos= Random.Range(-8,29);
                Instantiate(theEnemy, new Vector3(xPos, 0.9f, zPos), Quaternion.identity);
                yield return new WaitForSeconds(2f);
                enemyCount +=1;
            }
            waveNo +=1;
            yield return new WaitForSeconds(20f);
        } 
    }
}

