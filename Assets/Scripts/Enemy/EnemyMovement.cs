﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;


    void Awake ()
    {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> ();
    }


    void Update ()
	{
		if (MenuPanelController.IsMenuDisplayed) {
			nav.enabled = false;
			return;
		} else {
			nav.enabled = true;
		}

        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
			nav.SetDestination (player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
