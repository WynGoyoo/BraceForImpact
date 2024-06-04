using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public Rigidbody theRB;

    public float bulletSpeed = 8f;

    public float expireTime = 6f;

    public GameObject impacto;


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
        if (collision.gameObject.TryGetComponent<EnemyHealthController>(out EnemyHealthController enemyComponent))
        {
            //Debug.Log("Impacto");
            enemyComponent.TakeDamage(4);
            Instantiate(impacto, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        
    }





}
