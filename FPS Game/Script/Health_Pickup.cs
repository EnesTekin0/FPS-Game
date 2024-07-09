using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Pickup : MonoBehaviour
{
    public int giveHealth;
 
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<Character_Controller>() == null)
            return;
        
        Health_Manager. HurtPlayer(-giveHealth);
        
        Audio_Manager.instance.playHealth();
        
        Destroy(gameObject);
    }
}
