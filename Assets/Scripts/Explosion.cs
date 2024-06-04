using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource explosion;

    // Start is called before the first frame update
    void Start()
    {
        explosion.Play();
    }

    private void OnTriggerEnter(Collider other)
    {

        

        if (other.gameObject.TryGetComponent<EnemyHealthController>(out EnemyHealthController enemyComponent))
        {


            

            enemyComponent.TakeDamage(100);
            




        }



    }



    // Update is called once per frame
    void Update()
    {

    }

    public void Expiration()
    {
        Destroy(gameObject);
    }
}
