﻿using System.Collections;
using UnityEngine;




public class CarryBattery : MonoBehaviour
{
    public GameObject battery;
    public BatterySpawner batterySpawner;
    public int points;

    private bool wearing = false;
    private Animator animator;
    private audioController audioController;
    private PlayerMovement movement;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        audioController = GetComponent<audioController>();
        movement = GetComponent<PlayerMovement>();
        batterySpawner = GameObject.FindGameObjectWithTag("SpawnBattery").GetComponent<BatterySpawner>();
    }

    void Update()
    {
        if (wearing)
        {
            movement.slowed = true;
            battery.transform.position = transform.position + Vector3.up;
            if (Input.GetKey(KeyCode.R))
            {
                wearing = false;
            }
        }
        else
        {
            movement.slowed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        bool isAlive = GetComponent<LifeBar>().GetIsAlive();
        if(!isAlive)
        {
            wearing = false;
        }

        // Collect battery
        if (other.gameObject.CompareTag("Battery") && !wearing && isAlive)
        {
            battery = other.gameObject;
            animator.SetTrigger("catching");
            audioController.audioTake.Play();
            wearing = true; // TODO remove and start wearing at animation catch event
        }

        // Put battery in chamber
        if (other.gameObject.CompareTag("Chamber") && wearing && isAlive)
        {
            animator.SetTrigger("catching");
            audioController.audioWin.Play();
            wearing = false;
            battery.GetComponent<Collider>().enabled = false;
            battery.transform.position = other.transform.position + Vector3.up;
            batterySpawner.StartRespawn();
            points += 100;
		if (points >= 600)
            {
                GameObject.FindGameObjectWithTag("WinCanvas").GetComponent<ActivateWin>().WinScreen(GetComponent<PlayerManager>().playerId);
            }
        }
    }

	public void DropBattery()
	{
		battery.transform.position = transform.position;
		wearing = false;
	}
}
