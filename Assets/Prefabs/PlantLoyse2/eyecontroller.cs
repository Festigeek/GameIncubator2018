using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyecontroller : MonoBehaviour {

	GameObject playerTarget;
	//public GameObject fixedTarget;
	public GameObject eye;

	//public float sphereRadius = 5f;

	public float speed = 1.5f;

	float timer = 0;
	float timeLimit = 5;

	public float yOffset = 0.7f;

	public string playerTag = "Player";

	private Quaternion depart;
	private Quaternion arrivee;

	void Awake(){
		depart = transform.rotation;
		arrivee = transform.rotation;
	}

	// Use this for initialization
	void Start () {
		randomiseRotation ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerTarget) {
			eye.transform.LookAt (playerTarget.transform.position + Vector3.up * yOffset);
		} 
		else {
			timer += Time.deltaTime;
			if (timer >= timeLimit) {
				timer = 0;
				timeLimit = Random.Range (1, 3);

				randomiseRotation ();
			}

			eye.transform.rotation = Quaternion.Slerp (depart, arrivee, timer / timeLimit);
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log (gameObject.name + "Just Hit" + other.name);
		if (other.tag.Equals (playerTag)) {
			Debug.Log ("isPlayer");
			playerTarget = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other){
		Debug.Log (gameObject.name + "Just Exit" + other.name);
		if (other.gameObject == playerTarget) {
			Debug.Log ("Was player");
			playerTarget = null;
			randomiseRotation();
		}
	}

	void randomiseRotation(){

		depart = eye.transform.rotation;
		arrivee = Random.rotation;
		//arrivee = Quaternion.FromToRotation(eye.transform.position, fixedTarget.transform.position + Random.insideUnitSphere * sphereRadius);
	}
}
