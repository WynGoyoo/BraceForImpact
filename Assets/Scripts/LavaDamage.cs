using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{

    
    public EnemyData enemyData;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealthController>(out PlayerHealthController playerComponent))
        {
            Debug.Log("Impacto");
            playerComponent.TakeDamage(enemyData.damageLava);
            // Destroy(gameObject);
        }
    }
}
