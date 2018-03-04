using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	public AudioSource source;

	// Use this for initialization
	void Start () {
		source  = GetComponent<AudioSource>();
	}
	
	void playStressfull(){
		source.Play();
	}
}
