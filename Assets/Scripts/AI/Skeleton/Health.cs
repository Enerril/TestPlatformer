using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float initialHealth = 100;
    public TextMeshPro text;
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

        if (text != null)
        {
            text.text = initialHealth.ToString();
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
