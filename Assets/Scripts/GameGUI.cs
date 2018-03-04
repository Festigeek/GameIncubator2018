using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour {
    [HideInInspector]
    public List<GameObject> players = new List<GameObject>();

    public Text[] scores; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < players.Count; i++)
        {
            scores[players[i].GetComponent<PlayerManager>().playerId - 1].text = players[i].GetComponent<CarryBattery>().points.ToString();
            scores[players[i].GetComponent<PlayerManager>().playerId - 1].enabled = true;
        }
	}
}
