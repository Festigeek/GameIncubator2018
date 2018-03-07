using System.Collections;
using UnityEngine;




public class CarryBattery : MonoBehaviour
{
    
    public GameObject battery;
    public BatterySpawner batterySpawner;
    public int points;
    public float batteryOffsetY = 1.5f;

    private bool wearing = false;
    private Animator animator;
    private audioController audioController;
    private PlayerMovement movement;

    private GameInfo gi;

    private void Start()
    {
        gi = GameInfo.autoRef;
        if (!gi) {
            Debug.LogError("CarryBattery.cs: Script GameInfo n'a pas d'auto-référence statique !");
        }

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
            battery.transform.position = transform.position + Vector3.up * batteryOffsetY;

            battery.GetComponent<Collider>().enabled = false;
            /*
            if (Input.GetKey(KeyCode.R))
            {
                wearing = false;
            }
            */
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

            battery.GetComponent<Collider>().enabled = true;
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
            points += gi.scoreParCapture;
		    if (points >= gi.scoreLimit) {
                GameObject.FindGameObjectWithTag("WinCanvas").GetComponent<ActivateWin>().WinScreen(GetComponent<PlayerManager>().playerId);
            }
        }
    }

	public void DropBattery()
	{
        if (wearing) {
            battery.transform.position = transform.position;
            wearing = false;
            battery.GetComponent<Collider>().enabled = true;
        }
	}
}
