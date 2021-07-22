using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SawEnemy(GameObject attacker, GameObject prey);
public class Sight : MonoBehaviour
{
    public event SawEnemy _SawEnemy;
    // Start is called before the first frame update

    void Start()
    {
        var b = GameObject.FindGameObjectWithTag("Sight");
        var a = b.GetComponent<CapsuleCollider>();

    }

       // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter(Collider collision)
    {
       


        if (this.gameObject.tag=="Body" & collision.gameObject.tag == "BlueTank")
        {
            _SawEnemy?.Invoke(this.gameObject, collision.gameObject);
            Debug.Log(this.gameObject.tag.ToString() +" Noticed " + collision.gameObject.tag.ToString());
            return;
        }

        else if (this.gameObject.tag == "BlueTank" & collision.gameObject.tag == "RedTanûk")
        {
            _SawEnemy?.Invoke(this.gameObject, collision.gameObject);
            Debug.Log(this.gameObject.tag.ToString() + " Noticed " + collision.gameObject.tag.ToString());
            return;
        }
    }



}
