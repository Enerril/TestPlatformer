using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public delegate void OnHit(GameObject attacker, GameObject prey);
public class SwordHit : MonoBehaviour
{

    public event OnHit _OnHit;
    // Start is called before the first frame update
    void Start()
    {
        var a = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider collision)
    {


    }

}
