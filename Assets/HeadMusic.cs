using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMusic : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Debug.Log (gameObject.name + "Just Hit" + other.name);
		if (other.tag.Equals ("Player")) {
			Debug.Log ("isPlayer");
			AudioSource[] audios = GetComponents<AudioSource> ();
			audios [Random.Range (0, audios.Length - 1)].Play ();
		}
	}
}
