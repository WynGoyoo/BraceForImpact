using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 2f;

    public float limitX = 3f;
    public float limitY = 3f;
    public float limiteinferior = 0;


    public GameObject player;
    public CharacterController controller;


    private Vector3 moveDirection = Vector3.zero;



    public bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;

        player = GameObject.FindWithTag("PlayeStrafer");

    }

    // Update is called once per frame
    void Update()
    {



        transform.localPosition = Vector3.Lerp(transform.localPosition, player.transform.localPosition, speed * Time.deltaTime);



    }

}
