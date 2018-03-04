using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /// <summary>
    /// no du player utilisé sur les manettes, (0-3)
    /// </summary>
    public int playerId;
    public uint prefabIndex;

    private PlayerMovement movement;
    private PlayerController controller;
    private LifeBar lifeBar;

    void Start() {
        Setup();
    }

    public void Setup()
    {
        // setup movement
        movement = gameObject.GetComponent<PlayerMovement>();
        movement.m_PlayerId = playerId;
        movement.Setup();

        // setup controller
        controller = gameObject.GetComponent<PlayerController>();
        controller.playerId = playerId;
        controller.Setup();

        // setup lifebar
        lifeBar = gameObject.GetComponent<LifeBar>();
        lifeBar.ResetLife();
    }
}
