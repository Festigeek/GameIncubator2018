using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(Random.Range(0f, 90f), Random.Range(0f, 90f), Random.Range(0f, 90f)) * Time.deltaTime);
	}
}
