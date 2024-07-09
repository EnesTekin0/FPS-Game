using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public GameObject currentCheckPoint;
    private Character_Controller player;
    public Health_Manager healthManager;
    public float respawnDelay;
    public int penaltyToPoint;
    void Start()
    {
        player = FindObjectOfType<Character_Controller>();
        healthManager =FindObjectOfType<Health_Manager>();
    }
    public void RespawnPlayer()
    {
        StartCoroutine("PlayerRespawnCo");
    }
    public IEnumerator PlayerRespawnCo()
    {
        player.enabled = false;
        player.playerRB.velocity = Vector2.zero;
        Score_Manager.AddPoints(-penaltyToPoint);
        Debug.Log("Respawn Player");
        yield return new WaitForSeconds (respawnDelay);
        player.transform.position = currentCheckPoint.transform.position;
        player.knockbackCount = 0;
        player.enabled = true;
        healthManager.isDead = false;
        healthManager.FullHealth();
        Audio_Manager.instance.PlayPlayerRespawn();
    }
}
