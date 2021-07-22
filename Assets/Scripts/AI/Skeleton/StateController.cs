using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void Destroyed();

public class StateController : MonoBehaviour
{
    public event Destroyed Destroyed;
    [SerializeField] GameObject sightS;


    public bool isWandering, isFighting, isPursuing, isReachingGoal=false;

    Sight sight;
    
    FightMode fightMode;

    private void Awake()
    {

        isWandering = true;
        fightMode = GetComponent<FightMode>();
        GameObject g = GameObject.FindGameObjectWithTag("Sight");
        
        
     //   sight = sightS.GetComponent<Sight>() as Sight;
      
    }
    // Start is called before the first frame update

    private void OnEnable()
    {
        Debug.Log(sight);
     //   sight._SawEnemy += StartedFighting;

    }

    private void OnDisable()
    {
       // sight._SawEnemy -= StartedFighting;
        Destroyed?.Invoke();
    }

    private void OnDestroy()
    {
       // sight._SawEnemy -= StartedFighting;
        Destroyed?.Invoke();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void StartedFighting(GameObject attacker,GameObject prey) {

        isWandering = false;
        isFighting = true;
        fightMode.Players(attacker, prey);


    }





}
