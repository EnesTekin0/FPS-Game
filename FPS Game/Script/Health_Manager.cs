using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Manager : MonoBehaviour
{
    private Level_Manager levelManager;
    public int maxPlayerHealth;
    public static int playerHealth;
    public Slider healthBar;
    public bool isDead;
    private Life_Manager lifeSystem;
    
    void Start()
    {
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<Level_Manager>();
        healthBar = GetComponent<Slider>();
        lifeSystem = FindObjectOfType<Life_Manager>();
        isDead = false;
    }
    void Update()
    {
        if(playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            lifeSystem.TakeLife();
            levelManager. RespawnPlayer();
            isDead = true;
        }
            healthBar.value = playerHealth;
    }
    public static void HurtPlayer(int giveDamage)
    {
        playerHealth -= giveDamage;
    }
        public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
