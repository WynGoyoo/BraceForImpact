using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{

    public Transform target;
    public float positionSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, positionSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, positionSpeed * Time.deltaTime);
    }
}
