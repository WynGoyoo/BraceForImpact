using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticles : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform palote;
    private RectTransform selfTransform;

    public Camera cam;

    void Start()
    {
        selfTransform = GetComponent<RectTransform>();


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(palote.position);

        selfTransform.position = screenPos; 

    }
}
