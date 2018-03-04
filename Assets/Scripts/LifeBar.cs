//coder : Stéphane Blanc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class LifeBar : MonoBehaviour
{

    public float maxLife;
    private float currentLife;
    public UnityEvent OnDie;
    public Slider lifeSlider;


    //  private float timer=2f;


    void Awake()
    {
        if (OnDie == null)
            OnDie = new UnityEvent();

        ResetLife();

    }

    private void Update()
    {
        lifeSlider.value = currentLife;
        // DEBUG ///////////////
        /*if (Input.GetKeyDown("r"))
        {
            TakeDamage(1000);
        }*/
        /////////////////////////
    }

    /// <summary>
    /// Initialise ou réinitialise "currentLife" à "maxLife"
    /// </summary>
    public void ResetLife()
    {
        currentLife = maxLife;
    }
    /// <summary>
    /// Renvoie la vie actuelle
    /// </summary>
    /// <returns></returns>
    public float GetLife()
    {
        return currentLife;
    }

    public bool GetIsAlive()
    {
        return currentLife > 0F;
    }

    /// <summary>
    /// Ajoute "amount" à "currentLife", "currentLife" ne dépassera pas "maxLife"
    /// </summary>
    /// <param name="amount"></param>
    public void Heal(float amount)
    {
        if (amount < 0)
            amount = 0;

        currentLife = Mathf.Min(currentLife + amount, maxLife);
    }

    /// <summary>
    /// Retranche "amount" à "currentLife, limite la vie min à 0
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        if (amount < 0)
            amount = 0;

        currentLife = Mathf.Max(currentLife - amount, 0);

        if (currentLife == 0)
            IsDead();
    }

    /// <summary>
    /// Déclanche l'event OnDie
    /// </summary>
    public void IsDead()
    {
        PlayerMovement movement = GetComponent<PlayerMovement>();
        PlayerController controller = GetComponent<PlayerController>();

        movement.Disable();
        controller.Disable();

        Animator animator = GetComponentInChildren<Animator>();
        animator.SetBool("dead", true);

        GetComponent<audioController>().audioDeath.Play();

        Invoke("Revive", 5f);
    }

    private void Revive()
    {
        PlayerMovement movement = GetComponent<PlayerMovement>();
        PlayerController controller = GetComponent<PlayerController>();

        movement.Enable();
        controller.Enable();

        Animator animator = GetComponentInChildren<Animator>();
        animator.SetBool("dead", false);

        GetComponent<audioController>().audioresurect.Play();

        ResetLife();
    }
}
