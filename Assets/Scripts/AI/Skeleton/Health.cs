using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float initialHealth = 100;
    //public GameObject go;
    void Start()
    {
     //   var coll = go.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (initialHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter(Collider collision)
    {



        if (collision.gameObject.tag == "Sword")
        {
            initialHealth -= 35;
        }
    }
}
