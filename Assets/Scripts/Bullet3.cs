using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("choco con algo");

        if (collision.gameObject.TryGetComponent<EnemyHealthController>(out EnemyHealthController enemyComponent))
        {


            Debug.Log("Intento hacer daño");

            enemyComponent.TakeDamage(1);





        }

        Destroy(gameObject);

    }
}
