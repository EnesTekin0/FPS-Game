using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;
    public AudioSource ammo, player_Shoot, enemyDeath, player_Respawn, hurt_Player, health_audio;
    private void Awake()
    {
        instance = this;
    }
    public void Playammo()
    {
        ammo.Stop();

        ammo.Play();
    }
    public void PlayPlayerShoot()
    {
        player_Shoot.Stop();

        player_Shoot.Play();
    }
    public void PlayenemyDeath()
    {
        enemyDeath.Stop();

        enemyDeath.Play();
    }
    public void PlayPlayerRespawn()
    {
        player_Respawn.Stop();
        player_Respawn.Play();
    }
    public void PlayHurt()
    {
        hurt_Player.Stop();

        hurt_Player.Play();
    }
    public void playHealth()
    {
        health_audio.Stop();

        health_audio.Play();
    }
}
