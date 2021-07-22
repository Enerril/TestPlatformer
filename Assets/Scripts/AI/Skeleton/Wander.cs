using UnityEngine;

public class Wander : MonoBehaviour
{
    //public bool isWandering = true;

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 4f;
    private float characterVelocity = 4f; //Random.Range(.5f, 3f);
    public Vector3 movementDirection;
    private Vector3 movementPerSecond;
    public GameObject alien;
    StateController stateController;

    private void Start()
    {
        stateController = GetComponent<StateController>();
        latestDirectionChangeTime = Random.Range(2,8);
        CalcuateNewMovementVector();
    }

    private void CalcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;

      //  Debug.Log(movementDirection);
       // Debug.Log(movementPerSecond);
    }

    private void Update()
    {
        if (stateController.isWandering)
        {
            //if the changeTime was reached, calculate a new movement vector
            if (Time.time - latestDirectionChangeTime > directionChangeTime)
            {
                latestDirectionChangeTime = Time.time+ Random.Range(3, 8); 
                CalcuateNewMovementVector();
            }

            //move enemy:
            if (Vector3.Dot(transform.up, Vector3.down) < 0)
            {
                transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y, transform.position.z + (movementPerSecond.z * Time.deltaTime));

                alien.transform.rotation = Quaternion.Slerp(alien.transform.rotation, Quaternion.LookRotation(movementDirection), Time.deltaTime * 1.3f);
            }
            //alien.transform.rotation = Quaternion.LookRotation(movementDirection);
            //wait a set amount of timeeeeeee
            //if his movement is to the west, then he turns 90 in the y axis

           
        }
    }
}