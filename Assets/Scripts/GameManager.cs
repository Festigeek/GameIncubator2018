//
//  Created by Nohan Budry
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerInfo
    {
        public uint id;
        public uint prefabId;
    }

    /// <summary>
    /// The main camera
    /// </summary>
    public CameraManager mainCamera;
    public GameObject batteryPrefab;
    /// <summary>
    /// The List of the possibles player prafabes (skins)
    /// </summary>
    public GameObject[] playerPrefabs;
    public PlayerInfo[] playersInfos;

    /// <summary>
    /// Current list of player
    /// </summary>
    [HideInInspector]
    public List<PlayerManager> players;


    private Transform cube;
    private GameObject battery;

    public void Start()
    {
        /*players = new List<PlayerManager>();
        battery = Instantiate(batteryPrefab, Vector3.up / 2f + new Vector3(2, 0, 2), Quaternion.identity) as GameObject;
        foreach (var info in playersInfos)
        {
            GameObject player = Instantiate(playerPrefabs[info.prefabId], Vector3.up / 2f, Quaternion.identity) as GameObject;
            players.Add(new PlayerManager(info.id, info.prefabId, player));
            player.gameObject.GetComponent<CarryBattery>().battery = battery;
            mainCamera.AddTarget(player.transform);
        }*/
    }

    /// <summary>
    /// Add a new player to the game
    /// </summary>
    public void AddPlayer(uint id, uint prefabIndex)
    {
        /*PlayerManager player = new PlayerManager(id, prefabIndex);
        player.gameObject.GetComponent<CarryBattery>().battery = battery;*/
    }

    /// <summary>
    /// Remove a player of the game
    /// </summary>
    public void RemovePlayer(uint id)
    {
        foreach (var player in players)
        {
            if (player.playerId == id)
            {
                // Destroy the gameObject
                players.Remove(player);
            }
        }
    }


}
