using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{

    public int p1 = -1;
    public int p2 = -1;
    public int p3 = -1;
    public int p4 = -1;

    public List<GameObject> listPlayerPrefabs;

    public static GameInfo autoRef;

    public int scoreLimit = 500;
    public int scoreParCapture = 100;

    private void Awake()
    {
        autoRef = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public bool IsEnoughPlayersToStartGame()
    {
        return p1 + p2 + p3 + p4 >= -2;
    }
}

