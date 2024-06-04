using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activator : MonoBehaviour
{
    public GameObject Interceptor; 

    // Start is called before the first frame update
    void Start()
    {
        Interceptor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interceptor.SetActive(true);
        }
    }
}
