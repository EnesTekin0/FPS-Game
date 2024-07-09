using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Point : MonoBehaviour
{
    public Level_Manager levelManager;

    public Animator animator;
    void Start()
    {
        levelManager = FindObjectOfType<Level_Manager>();

        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name =="Player")
        {
            levelManager.currentCheckPoint = gameObject;
            
            animator.SetTrigger("active");

            Debug.Log("Aktif CheckPoint "+ transform.position);
        }
    }
}
