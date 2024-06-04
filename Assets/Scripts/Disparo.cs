using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Disparo : MonoBehaviour
{
    public Vector3 FireDirection = Vector3.zero;

    public GameObject joistickFire;

    public Animator anim;

    public GameObject disparoPrefabMisil;

    public GameObject disparoPrefabShot;

    public float fireRateMisil = 1f;

    public float fireRateShot = 1f;
    
    public Transform firePoint;

    public Transform firepoint2;

    public float fireCountShot;

    public float fireCountMisil;

    public GameObject multishoter;

    public GameObject Bomba;

    public float PowerGauge = 0;
    public float MaxPowerGauge = 100;

    public UnityEngine.UI.Image imageBarBomb;

    public AudioSource disparo;
    public AudioClip clip;

    public Quaternion Spread;


    

    // Start is called before the first frame update
    void Start()
    {
        PowerGauge = 0;

        

        joistickFire = GameObject.FindWithTag("Shooter");


    }

    // Update is called once per frame
    void Update()
    {
        //FireDirection = new Vector3(Input.GetAxisRaw("FireX"), Input.GetAxisRaw("FirY"), 0);

        //firepoint2.transform.localRotation = Quaternion.Euler(FireDirection);


       imageBarBomb.fillAmount = PowerGauge/ MaxPowerGauge;

        if (PowerGauge <= MaxPowerGauge)
        {
            PowerGauge += Time.deltaTime * 10;
        }



       

        if (fireCountMisil > 0) 
        {
            fireCountMisil -= Time.deltaTime;
        }
        
        if (fireCountShot > 0) 
        {
            fireCountShot -= Time.deltaTime;
        }


        if (SimpleInput.GetButton("Fire4") && fireCountMisil <= 0)
        {
            Fire();
            Fire();
            Fire();

        }
        
        if (SimpleInput.GetButton("Fire4") && fireCountShot <= 0)
        {

            Shot();
            disparo.PlayOneShot(clip, 1);
        }


        if(PowerGauge >= MaxPowerGauge)
        {
            if (SimpleInput.GetButton("Fire2"))
            {
                anim.SetTrigger("Fire");

                /*
                Instantiate(multishoter, transform.position, transform.rotation);

                PowerGauge = 0;
                */
            }


            if (SimpleInput.GetButton("Fire3"))
            {
                

                anim.SetTrigger("Fire");
              /*
                Instantiate(Bomba, firepoint2.transform.position, firepoint2.transform.rotation);
                PowerGauge = 0;
             */
            }
        }







    }


    public void Fire()
    {

        Spread = new Quaternion(0,transform.localEulerAngles.x + Random.Range(-50, 50),
                                                transform.localEulerAngles.y + Random.Range(-50, 50),
                                                transform.localEulerAngles.z + Random.Range(-50, 50));
        /*
        firePoint.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + Random.Range(-50, 50),
                                                transform.localEulerAngles.y + Random.Range(-50, 50),
                                                transform.localEulerAngles.z + Random.Range(-50, 50));
        */
        Instantiate(disparoPrefabMisil, firePoint.position, Spread);

        fireCountMisil = fireRateMisil;
        //firePoint.rotation.y = Random.Range(-70, 70);

    }    
    
    public void Shot()
    {
        
        Instantiate(disparoPrefabShot, firepoint2.position, firepoint2.transform.rotation);

        fireCountShot = fireRateShot;
        //firePoint.rotation.y = Random.Range(-70, 70);

    }
    
    public void Bomb()
    {

       
        Instantiate(multishoter, firepoint2.transform.position, firepoint2.transform.rotation);
        PowerGauge = 0;
        anim.ResetTrigger("Fire");

    }

   




}
