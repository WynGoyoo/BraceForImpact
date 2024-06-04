using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public EnemyData enemyData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealthController>(out PlayerHealthController playerComponent))
        {
            Debug.Log("Impacto");
            playerComponent.TakeDamage(enemyData.damage);
           // Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
