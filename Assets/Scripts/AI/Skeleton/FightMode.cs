using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMode : MonoBehaviour
{
    [SerializeReference]Transform bullet;
    [SerializeReference] GameObject gunEndPoint;

    GameObject attacker, prey;
    StateController stateController;
    float pauseBetweenShoot = 2f;

    StateController preyStateController;

   bool isCoroutineActive=false;

    public void Players(GameObject attacker, GameObject prey)
    {
        this.attacker = attacker;
        this.prey = prey;

        preyStateController = prey.GetComponent<StateController>();
        preyStateController.Destroyed += TargetDestroyed;
    }

    private void TargetDestroyed()
    {
        stateController.isFighting = false;
        stateController.isWandering = true;
        preyStateController.Destroyed -= TargetDestroyed;
    }

    Sight sight;
    Wander wander;
    private void Awake()
    {
        stateController = GetComponent<StateController>();
        sight = GetComponentInChildren<Sight>();
        wander = this.GetComponent<Wander>();
    }
    // Start is called before the first frame updat e

    private void OnEnable()
    {

      //  sight.SeeEnemy += BeginFight;
    }

    private void OnDisable()
    {
      //  sight.SeeEnemy -= BeginFight;

    }

    private void OnDestroy()
    {
      //  sight.SeeEnemy -= BeginFight;
    }

    private void RotateTowards()
    {
       // Debug.Log("occur");
         attacker.transform.root.LookAt(prey.transform.position);
       // attacker.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(prey.transform.position), 10*Time.deltaTime);
    }

    private void Shoot()
    {
        //if (prey != null) 
        //{ 
        //Transform bulletTransform = Instantiate(bullet, gunEndPoint.transform.position,
        //    //Quaternion.LookRotation(tankWander.movementDirection)
        //    Quaternion.Euler(this.gameObject.transform.rotation.x + 90, this.gameObject.transform.rotation.y + 90, this.gameObject.transform.rotation.z)
        //    );
        //Vector3 ShootDir = (((prey.transform.position + RandomizeAim()) - attacker.transform.position)).normalized ;
        //bulletTransform.GetComponent<Bullet>().Setup(ShootDir);
        //}
    }

    Vector3 RandomizeAim()
    {
        var x = UnityEngine.Random.Range(0f, 0.05f);
        var y = UnityEngine.Random.Range(0.02f, 0.05f);
        var z = UnityEngine.Random.Range(0f, 0.05f);


        return new Vector3(x, y, z);
    }
    void Update()
    {
        if (stateController.isFighting)
        {
            if (!isCoroutineActive)
            {
                StartCoroutine(BeginShooting());

            }
        }




    }

    private IEnumerator BeginShooting()
    {
        isCoroutineActive = true;
        RotateTowards();
        Shoot();

        yield return new WaitForSeconds(pauseBetweenShoot);

        

        isCoroutineActive = false;
    }


}


