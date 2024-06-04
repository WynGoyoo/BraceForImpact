using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject VFX;


    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("choco con algo");

        if (other.gameObject.TryGetComponent<EnemyHealthController>(out EnemyHealthController enemyComponent))
        {


            Debug.Log("Intento hacer daño");

            enemyComponent.TakeDamage(50);
            Instantiate(VFX, transform.position, transform.rotation);
           Destroy(gameObject);




        }



    
    }


}
