using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody theRB;

    public float bulletSpeed = 20f;

    public float expireTime = 6f;

    //public GameObject impacto;
    public GameObject player;

    public float rotateSpeed = 0.2f;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Destroy(gameObject, expireTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - theRB.position;

        direction.Normalize();

        Vector3 rotateAmount = Vector3.Cross(direction, transform.forward) * Vector3.Angle(transform.forward, direction);

        theRB.angularVelocity = -rotateAmount * rotateSpeed;

        theRB.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealthController>(out PlayerHealthController playerComponent))
        {
            //Debug.Log("Impacto");
            playerComponent.TakeDamage(4);
            // Instantiate(impacto, transform.position, transform.rotation);
            Destroy(gameObject);

        }

    }

    public void Muerte()
    {
        Destroy(gameObject);
    }
}
