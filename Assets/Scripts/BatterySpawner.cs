// Coder : Stéphane Blanc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fait apparaître aléatoirement la batterie vers l'un des points choisis
/// </summary>
public class BatterySpawner : MonoBehaviour {

    public List<RandomSpawnZone> potentialBatteryLocations; // Travail avec un préfab SpawnZone
    public GameObject battery;
    private GameObject batteryInstance;
    public float nbSecondsBeforeRespawn = 3f;

    void Start() {
        //print("COROORO");
        SpawnBattery();
    }

    /// <summary>
    /// Choisis une position aléatoire dans la liste "Locations" et fait
    /// initialise la batterie à un endroit aléatoire autour de cette postion.
    /// Le rayon d'apparition de la batterie est défini dans le script "SpawnZoneController" 
    /// par la fonction "GetRandomPosition()"
    /// </summary>
    public void SpawnBattery()
    {

        batteryInstance = Instantiate(battery, potentialBatteryLocations[Random.Range(0, potentialBatteryLocations.Count)].GetRandomPosition(), Quaternion.identity);
    }

    public void StartRespawn() {
        
        //print("COROORO");
        StartCoroutine(RespawnBattery(nbSecondsBeforeRespawn));
    }

    private IEnumerator RespawnBattery(float waitTime)
    {
        //print("STARTRESPAWN");
        yield return new WaitForSeconds(waitTime);
        //print("ASFSAFFASF");
        Destroy(batteryInstance);
        SpawnBattery();
    }

}
