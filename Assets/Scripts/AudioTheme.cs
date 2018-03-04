using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioTheme : MonoBehaviour {


    float volume = 0.2f;
  

    public AudioClip [] soundtrack;

    public AudioClip clipVictoryTheme;
    public AudioClip clipDarkTheme;
    public AudioClip clipMapTheme;

    private AudioSource audio;

    //public AudioSource audioVictoryTheme;
    //public AudioSource audioDarkTheme;
    //public AudioSource audioMapTheme;

    /*public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {

        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;

        return newAudio;
    }*/
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        //audioVictoryTheme = AddAudio(clipVictoryTheme, false, false, volume);
        //audioDarkTheme = AddAudio(clipDarkTheme, false, false, volume);
        //audioMapTheme = AddAudio(clipMapTheme, false, false, volume);
        StartCoroutine(playEngineSound());

    }
    IEnumerator playEngineSound()
    {
        while (true)
        {
            audio.clip = clipMapTheme;
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
            audio.clip = clipDarkTheme;
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
            audio.clip = clipVictoryTheme;
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
        }
    }
}
