// Coder : Stéphane Blanc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnZone : MonoBehaviour {

    public float Radius;
    /// <summary>
    /// Renvoie une position aléatoire dans un rayon défini autour de la zone de spawn
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRandomPosition()
    {
        Vector3 circle = Random.insideUnitSphere * Radius;
        circle.y = 0.5f;

        return transform.position + circle;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, Radius);
    }
}
