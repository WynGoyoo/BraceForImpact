using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    internal static bool paused;

    public TextMeshProUGUI puntosText;

    public int Puntos = 0;

    public MoneyData money;



 

    public static GameManager Singleton
    {
        //El get nos sirve para obtener la información del Singleton
        get
        {
            //Comprobamos primero que la instancia esté vacía
            if (instance == null)
            {
                //Rellenamos la referencia del Singleton
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                
                //Rellenamos la lista de objetivos
                
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private static GameManager instance;



    // Start is called before the first frame update
    void Start()
    {
        money.Coins = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //puntosText.text = "Puntos: " + Puntos;

    }

    //public void PlayerDied()
    //{
    //    //Llamamos a la corrutina
    //    StartCoroutine(PlayerDiedCo());
    //}

    //Creamos una corrutina para la muerte del jugador
//    public IEnumerator PlayerDiedCo()
//    {


//        //Reiniciamos la escena actual
//        Debug.Log("recargamos la escena");
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//    }
}
