using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody rb;

    public float Lifetime = 1;

    public float Speed = 80;

    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Lifetime = 0.8f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Lifetime > 0)
        {
            Lifetime -= Time.deltaTime;
        }




        rb.velocity = transform.forward * Speed * Lifetime;


        if (Lifetime <= 0)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
