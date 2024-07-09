using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int bullet;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            Character_Controller.instance.maxAmmo += bullet;

            Audio_Manager.instance.Playammo();

            Destroy(gameObject);
        }
    }
}
