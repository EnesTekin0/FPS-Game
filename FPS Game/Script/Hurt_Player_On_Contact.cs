using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_Player_On_Contact : MonoBehaviour
{
    public int giveDamage;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name =="Player")
        {
            Health_Manager.HurtPlayer (giveDamage);

            var player = other.GetComponent<Character_Controller>();
                player.knockbackCount = player.knockbackLenght;

            if (other.transform. position.x < transform.position.x)
                player.knockbackRight = true;
                
            else
                player.knockbackRight = false;

            Audio_Manager.instance.PlayHurt();
        }
    }
}
