using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMenu : MonoBehaviour
{

    public GameObject End;

    // Start is called before the first frame update
    void Start()
    {
        End = GameObject.FindGameObjectWithTag("Pauser");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player"))
       {
            ManagerGuardo.Instance.Save();
            Debug.Log("endgame");
            End.GetComponent<PauseManager>().EndGame();
       }
            
        
        
        
    }

}
