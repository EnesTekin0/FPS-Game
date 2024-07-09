using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public int damageAmount;

    public float bulletSpeed;

    public Rigidbody2D bulletRB;

    private Vector3 direction;

    
    void Start()
    {
    direction = Character_Controller.instance.transform.position-transform.position;
    direction. Normalize();
    direction = direction * bulletSpeed;
    }
    void Update()
    {
        bulletRB.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        Health_Manager.HurtPlayer (damageAmount);

        Destroy(gameObject);
    }
}
