using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Weapon class.
/// Need a collider on the weapon and th player with tag "Player"
/// </summary>
public class Weapon : MonoBehaviour
{
    public Attack[] attacks;

    private bool attacking = false;
    private bool damageDone = false;
    private float attackTimer = 0f;
    private AttackPower currentAttack = AttackPower.Quick;

    public void OnTriggerEnter(Collider other)
    {
        OnTriggerStay(other);
    }
    private void OnTriggerStay(Collider other)
    {
        if (!attacking || damageDone || IsOnDelay())//|| IsSelf(other))
            return;

        if (other.gameObject.CompareTag("Player"))
        {
            damageDone = true;
            DealDamage(other);
        }
    }

    private void FixedUpdate()
    {
        foreach (var attack in attacks)
        {
            attack.Update();
        }
        if (attacking)
        {
            attackTimer -= Time.fixedDeltaTime;
            if (attackTimer <= 0f)
            {
                CancelAttack();
                attacking = false;
            }
        }
    }
    /// <summary>
    /// Launchs the attack.
    /// </summary>
    /// <returns><c>true</c>, if attack was launched, <c>false</c> otherwise.</returns>
    /// <param name="attack">The power of the Attack. 0 -> Quick, 1-> Long</param>
    public bool LaunchAttack(AttackPower attack)
    {
        if (IsBlocking() || attacking)
            return false;

        currentAttack = attack;
        if (!GetCurrentAttack().Ready())
            return false;

        attackTimer = GetCurrentAttack().duration;
        attacking = true;

        // start attack animation

        return true;
    }

    private bool IsOnDelay()
    {
        return GetCurrentAttack().duration - attackTimer <= GetCurrentAttack().delay;
    }

    private bool IsBlocking()
    {
        Shield shield = GetComponentInChildren<Shield>();
        return shield.IsBlocking();
    }

    public Attack GetCurrentAttack()
    {
        return attacks[(int)currentAttack];
    }

    private void DealDamage(Collider other)
    {
        Shield shield = other.GetComponentInChildren<Shield>();

        if (shield.IsBlocking())
        {
            shield.damageShield(GetCurrentAttack().damage);
        }
        else
        {
            LifeBar lifeBar = other.GetComponent<LifeBar>();
            lifeBar.TakeDamage(GetCurrentAttack().damage);

			CarryBattery battery = other.GetComponent<CarryBattery> ();

			if (battery != null) {
				battery.DropBattery ();
			}
        }
    }

    public bool isAttcking()
    {
        return attacking;
    }

    public void CancelAttack()
    {
        attacking = false;
        damageDone = false;
        GetCurrentAttack().startCoolDown();
        // Cancel animation
    }

    private bool IsSelf(Collider other)
    {
        return other.GetComponent<PlayerManager>().playerId == GetComponent<PlayerManager>().playerId;
    }
}
