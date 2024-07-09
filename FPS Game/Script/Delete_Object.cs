using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Object : MonoBehaviour
{
    public float delete;
    
    void Update()
    {
        Destroy(gameObject, delete); 
    }
}
