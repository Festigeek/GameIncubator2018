using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBeltRotator : MonoBehaviour {



    // Update is called once per frame
 
    void Update () {
        transform.RotateAround(transform.position, transform.up, 20 * Time.deltaTime);
    }
}
