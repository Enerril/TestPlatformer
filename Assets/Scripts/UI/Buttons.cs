using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform beaconPosition;
   public GameObject enemyPrefab;
    Vector3 spawnPosition;

    void Start()
    {
       

    }
    // Update is called once per frame
        void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        spawnPosition = beaconPosition.transform.position;
        Instantiate(enemyPrefab, spawnPosition + new Vector3(-10,5,0),Quaternion.identity);
    }


}
