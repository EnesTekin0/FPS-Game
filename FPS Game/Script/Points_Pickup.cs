using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_Pickup : MonoBehaviour
{
    public int addPoints;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character_Controller>() == null)
            return;

        Score_Manager.AddPoints (addPoints);

        Destroy(gameObject);
    }
}
