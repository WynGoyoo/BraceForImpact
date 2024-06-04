using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody theRB;

    public float bulletSpeed = 8f;

    public float expireTime = 6f;

    //public GameObject impacto;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, expireTime);
    }

    // Update is called once per frame
    void Update()
    {
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

}
