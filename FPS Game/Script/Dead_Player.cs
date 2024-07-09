using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Player : MonoBehaviour
{
    public Level_Manager levelManager;
    void Start()
    {
        levelManager =FindObjectOfType<Level_Manager>();
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name =="Player")
        {
            levelManager.RespawnPlayer();
        }
    }
}
