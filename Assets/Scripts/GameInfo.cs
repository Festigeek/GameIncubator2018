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

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public bool IsEnoughPlayersToStartGame()
    {
        return p1 + p2 + p3 + p4 >= -2;
    }
}

