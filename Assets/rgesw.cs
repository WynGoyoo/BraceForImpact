using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rgesw : MonoBehaviour
{

    //public Transform Main;
    //public Transform Skins;
    //public Transform Shop;
    //public Transform Missions;
    //public Transform Options;

    public Transform Target;

    public float speed = 5f;



    // Start is called before the first frame update
    void Start()
    {


     
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime*speed);


        transform.rotation = Quaternion.Lerp(transform.rotation, Target.rotation, Time.deltaTime*speed);
  
    }


    public void ChangeTarget(Transform newTarget)
    {
        Target = newTarget;
    }
}
