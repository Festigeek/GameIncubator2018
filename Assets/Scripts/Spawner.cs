using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Alex Vouilloz

/// <summary>
/// Spawn une liste de maximum 8 objets, au hasard sur 8 positions autour d'un cercle de rayon "spawnRadius"
/// Si "isRandomSpawn" est true, l'objet est spawn sur une position au hasard autour d'une des 8 positions d'origine,
/// dans un rayon de "randomRadius"
/// </summary>
public class Spawner : MonoBehaviour {

    public List<GameObject> objectsList;
    public float spawnRadius;
    public bool isRandomSpawn;
    public float randomRadius;

    private List<Vector3> spawnPoints = new List<Vector3>();
    private readonly int NB_MAX_OBJETS = 8;
    private Random random = new Random();
    private List<int> playerNumbers;

    // Ajouté par Adrien Allemand

    public GameInfo gi;

    private void Awake()
    {
        gi = GameObject.FindGameObjectWithTag("GameInfo").GetComponent<GameInfo>();
        objectsList = new List<GameObject>();
        playerNumbers = new List<int>();
    }

    // end ajout

    /// <summary>
    /// Initialise les objets de la liste "objectsList"
    /// en cercle autour du spawner
    /// </summary>
    public void SpawnObjects()
    {
        if(gi.p1 >= 0) {

            objectsList.Add(gi.listPlayerPrefabs[gi.p1]);
            playerNumbers.Add(1);
        }
        if (gi.p2 >= 0)
        {

            objectsList.Add(gi.listPlayerPrefabs[gi.p2]);
            playerNumbers.Add(2);
        }
        if (gi.p3 >= 0)
        {

            objectsList.Add(gi.listPlayerPrefabs[gi.p3]);
            playerNumbers.Add(3);
        }
        if (gi.p4 >= 0)
        {

            objectsList.Add(gi.listPlayerPrefabs[gi.p4]);
            playerNumbers.Add(4);
        }

        objectsList = ShuffleList(objectsList);

        InitiatePositions(isRandomSpawn);
        for (int k = 0; k < objectsList.Count; k++)
        {
            //objectsList[k].GetComponent<PlayerManager>().playerId = playerNumbers[k];   // on modifie le prefab avant l'instanciation pour que les scriptes puissent récupérer dans le awake

            GameObject player = Instantiate(objectsList[k], spawnPoints[k], Quaternion.identity);
            player.GetComponent<PlayerManager>().playerId = playerNumbers[k];
            Debug.Log("Spawning player " + playerNumbers[k]);
        }
    }


    /// <summary>
    /// Crée une liste de 8 positions où faire apparaitre les objets
    /// </summary>
    private void InitiatePositions(bool isRandomSpawn)
    {
        spawnPoints.Add(new Vector3(spawnRadius * Mathf.Sqrt(2) / 2, 0.5f, spawnRadius * Mathf.Sqrt(2) / 2));
        spawnPoints.Add(new Vector3(-spawnRadius * Mathf.Sqrt(2) / 2, 0.5f, spawnRadius * Mathf.Sqrt(2) / 2));
        spawnPoints.Add(new Vector3(spawnRadius * Mathf.Sqrt(2) / 2, 0.5f, -spawnRadius * Mathf.Sqrt(2) / 2));
        spawnPoints.Add(new Vector3(-spawnRadius * Mathf.Sqrt(2) / 2, 0.5f, -spawnRadius * Mathf.Sqrt(2) / 2));
        spawnPoints.Add(new Vector3(spawnRadius, 0.5f, 0.0f));
        spawnPoints.Add(new Vector3(-spawnRadius, 0.5f, 0.0f));
        spawnPoints.Add(new Vector3(0.0f, 0.5f, spawnRadius));
        spawnPoints.Add(new Vector3(0.0f, 0.5f, -spawnRadius));

        if(isRandomSpawn)
        {
            for (int i = 0; i < NB_MAX_OBJETS; i++)
            { 
                spawnPoints[i] = GetRandomPosition(spawnPoints[i]);
            }
        }

        for (int k = 0; k < NB_MAX_OBJETS; k++)
        {
            spawnPoints[k] += transform.position;
        }
    }

    /// <summary>
    /// Renvoie une position aléatoire dans un rayon défini autour de la zone de spawn
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRandomPosition(Vector3 point)
    {
        Vector3 circle = Random.insideUnitSphere * randomRadius;
        circle.y = 0.5f;

        return point + circle;
    }

    private List<GameObject> ShuffleList(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Random.InitState(System.DateTime.UtcNow.Millisecond);
            GameObject temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return new List<GameObject>(list);
    }
}
