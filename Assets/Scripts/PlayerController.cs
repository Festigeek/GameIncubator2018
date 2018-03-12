// Quentin Gigon
// control attacks, shield and objects use

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Weapon weapon;
    private Shield shield;

    /*
    private string quickAttackCommand;
    private string longAttackCommand;
    private string shieldCommand;
    //private string useCommand;
    */

    private Animator animator;
    private audioController audioController;
    private PlayerManager pm;

    [SerializeField]
    private bool active = true;

    [SerializeField]
    float debug;

    public void Awake()
    {
        pm = GetComponent<PlayerManager>();
        if (!pm)
        {
            Debug.LogError("Player Controller: Can't find Player Manager script !");
        }
        animator = GetComponentInChildren<Animator>();
        if (!animator)
        {
            Debug.LogError("Player Controller: Can't find Animator !");
        }
        audioController = GetComponent<audioController>();

        if (!animator)
        {
            Debug.LogError("Player Controller: Can't find audioController ");
        }
        shield = GetComponentInChildren<Shield>();

        if (!shield) {
            Debug.LogError("Player Controller: Can't find shield ");
        }
        /*
        quickAttackCommand = "Atk_P" + pm.playerId;
        longAttackCommand = "Long_P" + pm.playerId;
        shieldCommand = "Shield_P" + pm.playerId;
        useCommand = "Use_P" + pm.playerId;
        Debug.Log("Player " + pm.playerId + " controls = " + quickAttackCommand + " " + longAttackCommand + " " + shieldCommand + " " + useCommand);
        */
    }

    private void Start()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>().AddTarget(gameObject.transform, 1);
        GameObject.FindGameObjectWithTag("GuiScores").GetComponent<GameGUI>().players.Add(gameObject);
    }

    // Update is called once per frame
    public void Update()
    {
        if (active)
        {
           // if (Input.GetButtonDown("Atk_P" + pm.playerId) || Input.GetAxisRaw("Atk_P" + pm.playerId) < -0.5)
            if (Input.GetAxisRaw("Atk_P" + pm.playerId) < -0.5) {   // "Atk_P1"

                Debug.Log("PlayerController: Attack Quick launched");
                if (weapon.LaunchAttack(AttackPower.Quick))
                {
                    Debug.Log("PlayerController: Weapon said ok for Quick");
                    animator.SetTrigger("quickAttack");
                    audioController.audioQuickAttack.Play();
                }
            }
            //if (Input.GetButtonDown("Atk_P" + pm.playerId) || Input.GetAxisRaw("Atk_P" + pm.playerId) > 0.5)
            if (Input.GetAxisRaw("Atk_P" + pm.playerId) > 0.5)
            {   // "Atk_P"
                if (weapon.LaunchAttack(AttackPower.Long))
                {
                    animator.SetTrigger("LongAttack");
                    audioController.audioLongAttack.Play();
                }
            }
            if (Input.GetButtonDown("Shield_P" + pm.playerId))
            {   // "Shield_P1" 
                shield.activateShield();
            }
            if (Input.GetButtonUp("Shield_P" + pm.playerId))
            {   // "Shield_P1" 
                shield.deactivateShield();
            }

        }
    }

    public void Enable()
    {
        active = true;
    }

    public void Disable()
    {
        active = false;
    }
}
