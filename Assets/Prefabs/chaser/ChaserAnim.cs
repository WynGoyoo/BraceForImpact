using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserAnim : MonoBehaviour
{
    public Animator anim;

    public GameObject player;

    public float distancia;


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

       
        
    }

    // Update is called once per frame
    void Update()
    {

        distancia = Vector3.Distance(transform.position, player.transform.position);

        if(distancia < 60)
        {
            anim.SetTrigger("atack");
        }
    }
}
