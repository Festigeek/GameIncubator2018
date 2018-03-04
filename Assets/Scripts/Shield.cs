// Quentin Gigon
// Important -> needs a sphere Gameobject to represent the shield
// activate the shield with activateShield() and get shield status with getShield()
// the shield sphere radius is changed according to remaining shieldHealth
// the shield color can be changed with setShieldColor()
// you can damage the shield using damageShield()

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour
{
    public float MAX_SHIELD_VALUE = 60f;              // max radius of shield sphere
    public float SHIELD_REGEN = 0.5f;                 // regen rate of shield
    public float MAX_SCALE = 7f;
    public float MIN_SCALE = 4f;
    public float cooldown = 0.75f;

    public GameObject shieldPrefab;    // sphere representing the shield
    //public GameObject shieldParent;

    private float shieldHealth;
    //private Renderer sphereRenderer;
    private bool isBlocking = false;
    private GameObject currentShield;
    private float cooldownTimer = 0f;
    private bool canBlock = true;

    void Awake()
    {
        shieldHealth = MAX_SHIELD_VALUE;
    }

    void FixedUpdate()
    {
        if (isBlocking)
        {

            shieldHealth -= SHIELD_REGEN;
            if (shieldHealth <= 0f)
            {
                shieldHealth = 0f;
                deactivateShield();
            }
        }
        else if (shieldHealth < MAX_SHIELD_VALUE)
        {

            shieldHealth += SHIELD_REGEN; // for a slower regen
            if (shieldHealth > MAX_SHIELD_VALUE)
            {
                shieldHealth = MAX_SHIELD_VALUE;
            }
        }

        if (currentShield != null)
        {
            changeShieldSize();
        }

        if (cooldownTimer <= 0f)
        {
            canBlock = true;
        }
        else
        {
            cooldownTimer -= Time.fixedDeltaTime;
        }
    }

    public void activateShield()
    {
        if (!IsAttacking() && canBlock)
        {
            currentShield = Instantiate(shieldPrefab) as GameObject;
            currentShield.transform.parent = transform;
            currentShield.transform.position = transform.position;
            isBlocking = true;
        }
    }

    public void deactivateShield()
    {
        isBlocking = false;
        if (currentShield != null)
        {
            Destroy(currentShield);
        }

        if (canBlock)
        {
            cooldownTimer = cooldown;
            canBlock = false;
        }
    }

    public void damageShield(float damage)
    {
        shieldHealth -= Mathf.Min(damage, shieldHealth);
    }

    private void changeShieldSize()
    {
        //if (shieldHealth < MAX_SHIELD_VALUE)
        //{
        //    currentShield.transform.localScale = new Vector3(shieldHealth / 10f, shieldHealth / 10f, shieldHealth / 10f);
        //}
        float scale = Mathf.Lerp(MIN_SCALE, MAX_SCALE, shieldHealth / MAX_SHIELD_VALUE);
        currentShield.transform.localScale = Vector3.one * scale;
    }

    public bool IsBlocking()
    {
        return isBlocking;
    }

    private bool IsAttacking()
    {
        // MODIFIED BY ADRIEN AFTER 
        //Weapon weapon = GetComponentInChildren<Weapon>();
        Weapon weapon = GetComponentInParent<Weapon>();
        return weapon.isAttcking();
    }
}
