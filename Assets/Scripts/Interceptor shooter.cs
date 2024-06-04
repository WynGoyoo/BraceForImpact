using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interceptorshooter : MonoBehaviour
{

    public GameObject player;

    public GameObject Projectile;

    public GameObject Barrel;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {


        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = player.transform.position - rb.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        Barrel.transform.rotation = targetRotation;

    }


    public void Shoot()
    {
        Instantiate(Projectile, Barrel.transform.position, Barrel.transform.rotation);
    }

}

