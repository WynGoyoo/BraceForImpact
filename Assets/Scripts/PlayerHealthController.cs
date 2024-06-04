using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public float currentHealth = 20;
    public float maxHealth = 20;
   
    private Animator anim;

    public GameObject pauser;
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        pauser = GameObject.FindGameObjectWithTag("Pauser");
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log("Daño");
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {

            anim.SetBool("Death",true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Destroy();
            
        }
    }

    public void Destroy()
    {
        Debug.Log("muere");
        pauser.GetComponent<PauseManager>().Pausegame();

    }

    public void Revive()
    {
        Debug.Log("Revive");
        anim.SetBool("Death", false);
        pauser.GetComponent<PauseManager>().ResumeGame();
        //anim.SetTrigger("Revive");
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(currentHealth < maxHealth || currentHealth >= 0)
    //    {
    //        currentHealth += Time.deltaTime * 0.5f;
    //    }

    //    if(currentHealth > maxHealth)
    //    {
    //        currentHealth = maxHealth;
    //    }
    //}
}
