// Quentin Gigon
// control attacks, shield and objects use
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerId;
    public Weapon weapon;
    public Shield shield;

    private string quickAttackCommand;
    private string longAttackCommand;
    private string shieldCommand;
    private string useCommand;
    private bool settedUp = false;
    private Animator animator;
    private audioController audioController;

    private bool active = true;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>().AddTarget(gameObject.transform, 1);
        GameObject.FindGameObjectWithTag("GuiScores").GetComponent<GameGUI>().players.Add(gameObject);
    }

    // Use this for initialization
    public void Setup()
    {
        settedUp = true;
        animator = GetComponentInChildren<Animator>();
        audioController = GetComponent<audioController>();

        quickAttackCommand = "Quick_P" + playerId;
        longAttackCommand = "Long_P" + playerId;
        shieldCommand = "Shield_P" + playerId;
        useCommand = "Use_P" + playerId;
    }

    // Update is called once per frame
    public void Update()
    {
        if (settedUp && active)
        {
            if (Input.GetButtonDown(quickAttackCommand) || Input.GetAxisRaw(quickAttackCommand) > 0.1)
            {   // "Quick_P1"
                if (weapon.LaunchAttack(AttackPower.Quick))
                {
                    animator.SetTrigger("quickAttack");
                    audioController.audioQuickAttack.Play();
                }
            }
            if (Input.GetButtonDown(longAttackCommand) || Input.GetAxisRaw(longAttackCommand) > 0.1)
            {   // "Long_P1"
                if (weapon.LaunchAttack(AttackPower.Long))
                {
                    animator.SetTrigger("LongAttack");
                    audioController.audioLongAttack.Play();
                }
            }
            if (Input.GetButtonDown(shieldCommand))
            {   // "Shield_P1" 
                shield.activateShield();
            }
            if (Input.GetButtonUp(shieldCommand))
            {   // "Shield_P1" 
                shield.deactivateShield();
            }
            //if (Input.GetButtonDown(useCommand))
            //{   // "Use_P1
            //    Debug.Log("USE_P1");
            //}
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
