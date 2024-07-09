using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy_Control : MonoBehaviour
{
    public int enemyHealth;
    public Rigidbody2D enemyRb;
    public float playerRange;
    public float enemySpeed;
    public int addPoint;
    public GameObject bonus;
    public bool shoot;
    public float fireRate;
    private float shootCounter;
    public GameObject bullet;
    public GameObject explosion;
    public Transform firePoint;

    void Update()
    {
        if(Vector3.Distance (transform.position, Character_Controller.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = Character_Controller.instance.transform.position - transform.position;
            enemyRb.velocity = playerDirection.normalized * enemySpeed;
        
            if (shoot)
            {
                shootCounter -=  Time.deltaTime;
                if (shootCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, transform.rotation);

                    shootCounter = fireRate;
                }
            }
        }
        else
        {
            enemyRb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage()
    {   
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate (explosion, transform.position, transform.rotation);
            Instantiate(bonus, transform.position, Quaternion.identity);
            Audio_Manager.instance.PlayenemyDeath();
            Score_Manager.AddPoints(addPoint);
        }
    }
}
