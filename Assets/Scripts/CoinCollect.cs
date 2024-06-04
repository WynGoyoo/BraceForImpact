using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{

    public GameObject player;

    public float distancia;


    public float speed = 300;
    
    public Rigidbody rb;

    public float rotatespeed = 300;

    public AudioSource audiosource;
    public AudioClip clip;
    public MoneyData money;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);

        //rotatespeed = rotatespeed * Time.deltaTime;

        if (distancia < 60)
        {
            Vector3 direction = player.transform.position - rb.position;
           
            direction.Normalize();
           
            Vector3 rotateammount = Vector3.Cross(direction, transform.forward) * Vector3.Angle(transform.forward, direction);
           
            rb.angularVelocity = -rotateammount * rotatespeed;
           
            rb.velocity = transform.forward * speed;

            


        }

    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag ("Player"))
        {
            
            Destroy(gameObject);
            ScoreManager.Singleton.scoreCount = ScoreManager.Singleton.scoreCount + 1;

            //Debug.Log("me ha dado" + other.gameObject.name);
            audiosource.PlayOneShot(clip, 1);
            money.Coins += 1;
            
        }
    }


}
