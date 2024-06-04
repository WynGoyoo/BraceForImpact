using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class limiters : MonoBehaviour
{
    public GameObject flechaL;
    public GameObject flechaR;
    public GameObject flechaU;
    public GameObject flechaD;

    public float limitLeft = -22f;
    public float limitUp = 22;
    public float limitDown = 4;
    public float limitRight = 22;

    public float xCopyer;
    public float yCopyer;

    public GameObject player;

    public Vector3 Copyer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayeStrafer");

        flechaL.SetActive(false);
        flechaR.SetActive(false);
        flechaU.SetActive(false);
        flechaD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        Copyer = player.transform.localPosition;

        xCopyer= Copyer.x;
        yCopyer= Copyer.y;


        if(xCopyer >= limitRight)
        {
            flechaR.SetActive(true);
        }
        else if(xCopyer <= limitLeft)
        {
            flechaL.SetActive(true);
        }
        else
        {
            flechaL.SetActive(false);
            flechaR.SetActive(false);
        }

        if(yCopyer >= limitUp)
        {
            flechaU.SetActive(true);
        }
        else if(yCopyer <= limitDown)
        {
            flechaD.SetActive(true);
        }
        else
        {
            flechaU.SetActive(false);
            flechaD.SetActive(false);
        }
    }
}
