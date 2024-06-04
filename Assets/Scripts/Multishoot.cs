using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Multishoot : MonoBehaviour
{
    public int rebotes = 10;

    public List<Transform> enemigos;


    public string tagToDetect = "Enemy";
    public GameObject[] allEnemies;
    public GameObject closestEnemy;


    public float lifetime = 1;

    public GameObject Beam;

    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {

        rebotes = 13;


        LockOn();
        //allEnemies = GameObject.FindGameObjectsWithTag(tagToDetect);

        if (enemigos.Count <= 0)
        {
            Destroy(gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {


        lifetime = lifetime - Time.deltaTime;

        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }

    }



    public void LockOn()
    {
        GameObject[] objetosEnemigo = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject objeto in objetosEnemigo)
        {
            enemigos.Add(objeto.transform);
        }


        // Si no hay enemigos, no hacemos nada
        if (enemigos.Count == 0)
        {
            Destroy(gameObject);




        }

        // Ordenar la lista por distancia
        enemigos.Sort((a, b) => Vector3.Distance(transform.position, a.position).CompareTo(Vector3.Distance(transform.position, b.position)));

        Transform enemigoMasCercano = enemigos[0];
        float distanciaMasCercana = Vector3.Distance(transform.position, enemigoMasCercano.position);

        Debug.Log("El enemigo más cercano está a una distancia de: " + distanciaMasCercana);


        //enemigos.Clear();

        //rebotes = enemigos.Count;



        DispararRayo();



    }

    void DispararRayo()
    {




        if (enemigos.Count <= 0)
        {
            Debug.Log("No hay enemigos para disparar el rayo.");



            Destroy(gameObject);
        }

        Transform enemigoActual = enemigos[0]; // Enemigo más cercano

        //Vector3 direccion = (enemigoActual.position - firepoint.position).normalized;
        //RaycastHit hit;

        //if (Physics.Raycast(firepoint.position, direccion, out hit))
        //{
            // Comprobar si el rayo ha golpeado a un enemigo
            //if (hit.collider.gameObject.CompareTag("Enemy"))
            //{
                //Debug.Log("Rayo golpeó a: " + hit.collider.gameObject.name);

        


        Instantiate(Beam, enemigoActual.transform.position, enemigoActual.transform.rotation);
        rebotes--;

        if (rebotes <= 0)
        {
            Destroy(gameObject);
        }

        // Mueve la posición de inicio del rayo al punto de impacto
        //transform.position = hit.point;

        // Quita el enemigo golpeado de la lista
        enemigos.Remove(enemigoActual);
            //}

        //}

        // Si quedan enemigos en la lista, disparamos el rayo nuevamente
        if (enemigos.Count > 0 && rebotes > 0)
        {
            DispararRayo();
        }
        if (enemigos.Count <= 0)
        {
            Debug.Log("todos han sido disparados");

            Destroy(gameObject);


        }

        if (rebotes <= 0)
        {
            Destroy(gameObject);
        }
        if (enemigos.Count <= 0)
        {
            Destroy(gameObject);
        }

    }

}
