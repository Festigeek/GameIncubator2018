// Quentin Gigon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int m_PlayerId = 1;         // id of the player
    public float m_Speed = 6f;         // speed of player
    public float m_SlowedSpeed = 4f;
    public float m_TurnSpeed = 1.5f;      // turn speed of player
    public bool slowed = false;

    private audioController audioController;


    private string m_VerticalMovementName;
    // The name of the input axis for moving forward and back.
    private string m_HorizontalMovementName;
    // The name of the input axis for turning.
    private string m_AimVerticalName;
    private string m_AimHorizontalName;
    private Rigidbody m_Rigidbody;
    // Reference used to move the tank.
    private float m_VerticalValue;
    // The current value of the movement input.
    private float m_HorizontalValue;
    // The current value of the turn input.
    private float m_AimVerticalValue;
    private float m_AimHorizontalValue;

    private bool m_SettedUp = false;
    private Animator animator;

    private bool active = true;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    public void Enable()
    {
        // make sure player is not kinematic when turned on
        //m_Rigidbody.isKinematic = false;

        // reset the input values.  
        //m_VerticalValue = 0f;
        //m_HorizontalValue = 0f;
        active = true;
    }


    public void Disable()
    {
        // set it to kinematic when killed so it stops moving.
        //m_Rigidbody.isKinematic = true;
        active = false;
    }

    // Use this for initialization
    public void Setup()
    {
        // The axes names are based on player ID.
        m_VerticalMovementName = "Vertical_P" + m_PlayerId;
        m_HorizontalMovementName = "Horizontal_P" + m_PlayerId;
        m_AimVerticalName = "AimVertical_P" + m_PlayerId;
        m_AimHorizontalName = "AimHorizontal_P" + m_PlayerId;

        m_SettedUp = true;
    }

    void Update()
    {
        if (m_SettedUp && active)
        {
            m_VerticalValue = Input.GetAxis(m_VerticalMovementName);
            m_HorizontalValue = Input.GetAxis(m_HorizontalMovementName);
            m_AimVerticalValue = Input.GetAxis(m_AimVerticalName);
            m_AimHorizontalValue = Input.GetAxis(m_AimHorizontalName);
        }
    }

    void FixedUpdate()
    {
        if (m_SettedUp && active)
        {
            Turn();
            Move();
        }
    }

    private void Move()
    {
        //Vector3 movement = new Vector3(m_TurnInputValue, 0f, m_MovementInputValue) * m_Speed * Time.deltaTime;
        //if (movement.magnitude != 0) animator.SetBool("inMotion", true);
        //else animator.SetBool("inMotion", false);                            // Stat for animation
        //m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        Vector3 movement = new Vector3(m_HorizontalValue, 0f, m_VerticalValue) * (slowed ? m_SlowedSpeed : m_Speed) * Time.deltaTime;
        if (movement.magnitude > float.Epsilon)
        {
            animator.SetBool("inMotion", true);
            m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
            m_Rigidbody.velocity = Vector3.zero;
        }
        else
        {
            animator.SetBool("inMotion", false);
        }
    }

    private void Turn()
    {
        Vector3 direction = new Vector3(-m_AimVerticalValue, 0, m_AimHorizontalValue);
        if (direction.magnitude > float.Epsilon)
        {
            transform.LookAt(transform.position + direction);
        }
    }
}
