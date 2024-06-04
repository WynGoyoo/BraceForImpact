using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float currentHealth = 20;
    public EnemyData enemyData;

    public void Start()
    {
        currentHealth = enemyData.maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        //Debug.Log("Daño");
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            //Debug.Log("Muere");
            ComandosSQLite.Instance.AddKillToDB();
            Destroy(gameObject);
        }
    }
    public void Muerte()
    {
        Destroy(gameObject);
    }


}
