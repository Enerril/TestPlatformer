using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    Rigidbody rb;
    Animator anim;

    float xMin;
    float xMax;
    float yMin;
    float yMax;


    public float speed = 5F;
    float rotationSpeed = 150.0F;


 //   Coroutine animCoroutine;
 //  bool coroutBool;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponentInChildren<Rigidbody>();
        anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        //if (!coroutBool)
        //{
        //    if (Input.GetButtonDown("Jump"))
        //    {

        //        animCoroutine = StartCoroutine(animationCDCoroutine());

        //    }
        //}

        if (Input.GetKey(KeyCode.Space))
        {

            anim.Play("DS_onehand_attack_A");
        }

        //if (Input.GetButtonUp("Jump"))
        //{

        //    StopCoroutine(animCoroutine);
        //    coroutBool = false;
        //}


    }


    private void Move()
    {



        //anim.SetBool("IsWandering", true);
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        if (translation > 0)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("DS_onehand_walk"))
            {
                anim.Play("DS_onehand_walk");
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("DS_onehand_walk")) 
            {
                translation *= Time.deltaTime;
                rotation *= Time.deltaTime;
                Quaternion turn = Quaternion.Euler(0f, rotation, 0f);
                rb.MovePosition(rb.position + this.transform.forward * translation);
                rb.MoveRotation(rb.rotation * turn);

            }


        }

        //  anim.SetBool("IsWandering", false);
    }
    //IEnumerator animationCDCoroutine()
    //{
    //    coroutBool = true;
    //    while (true)
    //    {
    //        anim.Play("DS_onehand_attack_A");
    //        coroutBool = false;
    //    }
    //    yield return new WaitForSeconds(2);

    //}

}
