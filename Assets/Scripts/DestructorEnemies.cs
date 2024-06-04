using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DestructorEnemies : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealthController>(out EnemyHealthController EnemyComponent))
        {
            
            EnemyComponent.Muerte();
            
            
        }

        if (collision.gameObject.TryGetComponent<EnemyProjectile>(out EnemyProjectile proojectile))
        {
            proojectile.Muerte();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
