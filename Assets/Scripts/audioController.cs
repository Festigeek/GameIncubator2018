using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour {

    float volume = 0.8f;

    
    public AudioClip clipTake;
    public AudioClip clipWin;
    public AudioClip clipDeath;
    public AudioClip clipResurect;
    public AudioClip clipQuickAttack;
    public AudioClip clipLongAttack;

    
    public AudioSource audioTake;
    public AudioSource audioWin;
    public AudioSource audioDeath;
    public AudioSource audioresurect;
    public AudioSource audioQuickAttack;
    public AudioSource audioLongAttack;


    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {

        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;

        return newAudio;
    }

public void Awake()
{
        // add the necessary AudioSources:
        
        audioTake = AddAudio(clipTake, false, false, volume);
        audioWin = AddAudio(clipWin, false, false, volume);
        audioDeath = AddAudio(clipDeath, false, false, 1f);
        audioresurect = AddAudio(clipResurect, false, false, 1f);
        audioQuickAttack = AddAudio(clipQuickAttack, false, false, volume);
        audioLongAttack = AddAudio(clipLongAttack, false, false, volume);
    }


// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
