using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet2 : MonoBehaviour
{
    public GameObject target;

    public float weakTime = 1f;


    public float speed = 5f;
    public float rotateSpeed = 200f;
    public float expireTime = 4f;
    private Rigidbody rb;

    public GameObject impacto;
    // Use this for initialization
    void Start()
    {
        

        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, expireTime);
        EncontrarEnemigoMasCercano();
    }
    private void Update()
    {
        if (weakTime > 0)
        {
            weakTime -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {

        if (weakTime > 0)
        {

            
            rotateSpeed = 0.1f;
        }
        if (weakTime < 0)
        {
            rotateSpeed = 200f * Time.deltaTime;
        }
        if(target == null)
        {
            EncontrarEnemigoMasCercano();
        }
        if(target != null) { 
        Vector3 direction = target.transform.position - rb.position;

        direction.Normalize();

        Vector3 rotateAmount = Vector3.Cross(direction, transform.forward) * Vector3.Angle(transform.forward,direction);

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.forward * speed;
          

            }

    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealthController>(out EnemyHealthController enemyComponent))
        {
            //Debug.Log("Impacto");
            enemyComponent.TakeDamage(3);
            Instantiate(impacto, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Escenario"))
        {
            Destroy(gameObject);
        }
        
    }


    void EncontrarEnemigoMasCercano()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        
        float distanciaMinima = Mathf.Infinity;

        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                target = enemigo;
            }
        }

       
    }
}
