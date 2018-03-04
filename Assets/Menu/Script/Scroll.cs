
using UnityEngine;
using System.Collections;


public class Scroll : MonoBehaviour {

    public float scroolSpeed = 20;

	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);
        pos += localVectorUp * scroolSpeed * Time.deltaTime;
        transform.position = pos; 
	}
}
