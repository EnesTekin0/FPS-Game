using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Life_Manager : MonoBehaviour
{
    public int startingLifes;
    private int lifeCounter; 
    TextMeshProUGUI lifeText;
    public GameObject gameOverScreen;
    private Character_Controller player;
    void Start()
    {
        lifeText = GetComponent<TextMeshProUGUI>();
        lifeCounter = startingLifes;
        player = FindObjectOfType<Character_Controller>();
    }
    void Update()
    {
        if(lifeCounter <= 0)
        {
            SceneManager.LoadScene(2);
            //gameOverScreen.SetActive(true);
            //player.gameObject.SetActive(false);
        }
        lifeText.text = "Live : "+ lifeCounter;
    }
    public void GiveLife() 
    {
        lifeCounter++;
    }
    public void TakeLife()
    {
        lifeCounter--;
    }
}
