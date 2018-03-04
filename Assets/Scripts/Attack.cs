using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackPower { Quick, Long }
public enum AttackType { Melee, Range }

[System.Serializable]
public class Attack
{
    public AttackType type = AttackType.Melee;
    public float duration;
    public float delay;
    public float cooldown;
    public float damage;
    public GameObject Bullet = null;

    private float cooldownTimer = 0f;

    public bool Ready()
    {
        return cooldownTimer <= 0f;
    }

    public void startCoolDown()
    {
        cooldownTimer = cooldown;
    }

    public void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.fixedDeltaTime;
        }
    }
}
