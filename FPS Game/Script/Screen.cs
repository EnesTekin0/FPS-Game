using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    private SpriteRenderer theSR;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.LookAt(Character_Controller.instance.transform.position, -Vector3.forward);
    }
}
