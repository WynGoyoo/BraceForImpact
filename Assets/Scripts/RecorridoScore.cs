using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecorridoScore : MonoBehaviour
{
    public Text textoScore;
    public static float score;

    public Text textoHiScore;
    public static float hiScore;

    public Transform cheackPoint;
    public Transform player;







    //void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    //    hiScore = PlayerPrefs.GetFloat("Hi-Score");

    //    if (textoHiScore != null )
    //    {
    //        textoHiScore.text = "Hi-Score Acyual " + hiScore.ToString("F0");
    //    }
    //}


    void Update()
    {
        score = (cheackPoint.transform.position - player.transform.position).magnitude;

        textoScore.text = "Score: " + score.ToString("F0");
    }

    public void sumarScore() 
    {
        hiScore = hiScore + score;
        textoHiScore.text = "Hi-Score: " + hiScore;
        
    }

    //public void ActualizarHighScore()
    //{
    //    hiScore = PlayerPrefs.GetFloat("HighScore");

    //    if(score > hiScore) 
    //    {
    //        score = hiScore;
    //        PlayerPrefs.SetFloat("HighScore", hiScore);
    //    }
    //}

}
