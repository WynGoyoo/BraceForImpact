using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int scoreCount;


    public static ScoreManager Singleton
    {
        //El get nos sirve para obtener la información del Singleton
        get
        {
            //Comprobamos primero que la instancia esté vacía
            if (instance == null)
            {
                //Rellenamos la referencia del Singleton
                instance = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;

                //Rellenamos la lista de objetivos

            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private static ScoreManager instance;

    // Start is called before the first frame update
    void Start()
    {
       // Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = "Coins: " + Mathf.Round(scoreCount);
    }

   
}
