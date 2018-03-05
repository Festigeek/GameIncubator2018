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

    private LifeBar lifeBar;

    void Start() {
        Setup();
    }

    public void Setup()
    {

        // setup lifebar
        lifeBar = gameObject.GetComponent<LifeBar>();
        lifeBar.ResetLife();
    }
}
