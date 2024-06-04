using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float dashingTime = 0.3f;
    public bool isDashing;
    Vector3 dashDirection;
    public float speed = 2f;
    public float dashCD = 0.5f;
    public float dashingSpeed = 30;

    public float limitX = 3f;
    public float limitY = 3f;
    public float limiteinferior = 0;
    public bool canMove;

    public Animator anim;

    public AudioSource Dashh;

    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("x", SimpleInput.GetAxisRaw("Horizontal"));
        anim.SetFloat("y", SimpleInput.GetAxisRaw("Vertical"));

        dashDirection = new Vector3(SimpleInput.GetAxisRaw("Horizontal"), SimpleInput.GetAxisRaw("Vertical"), 0);
        dashDirection = transform.TransformDirection(dashDirection);

        if (dashCD > 0)
        {
            dashCD -= Time.deltaTime;
        }

        if (SimpleInput.GetButton("g") && dashCD < 0)
        {
            Dashh.Play();
            isDashing = true;
        }


        if (isDashing)
        {

            anim.SetBool("Dash", true);



            controller.Move(dashDirection.normalized * dashingSpeed * Time.deltaTime);

            
            Debug.Log("Dash");


            StartCoroutine(StopDashing());

        }





        if (canMove == true)
        {
            moveDirection = new Vector3(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"), 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (SimpleInput.GetButton("Jump"))
                Debug.Log("Aquí hago cositas");

        }



        controller.Move(moveDirection * Time.deltaTime);


        //LIMITES

        if (transform.localPosition.y < limiteinferior)
        {

            transform.localPosition = new Vector3(transform.localPosition.x, limiteinferior, transform.localPosition.z);
        }

        if (transform.localPosition.y > limitY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, limitY, transform.localPosition.z);
        }


        if (transform.localPosition.x > limitX)
        {

            transform.localPosition = new Vector3(limitX, transform.localPosition.y, transform.localPosition.z);
        }


        if (transform.localPosition.x < -limitX)
        {

            transform.localPosition = new Vector3(-limitX, transform.localPosition.y, transform.localPosition.z);
        }

    }


    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);

        isDashing = false;

        anim.SetBool("Dash", false);

        dashCD = 0.2f;
        Debug.Log("Stop dash");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            ScoreManager.Singleton.scoreCount += 1;
        }
    }
}
