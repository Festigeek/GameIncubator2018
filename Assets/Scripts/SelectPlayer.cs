using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayer : MonoBehaviour {

    private GameInfo gi;
    public GameObject gameInfoPrefab;

    public Text labelP1;
    public Text labelP2;
    public Text labelP3;
    public Text labelP4;

    private bool playing = false;

    public AudioSource audio;

    private GameObject characterP1;
    private GameObject characterP2;
    private GameObject characterP3;
    private GameObject characterP4;
    public GameObject characterPositionP1;
    public GameObject characterPositionP2;
    public GameObject characterPositionP3;
    public GameObject characterPositionP4;
    public GameObject[] characterMenuPrefabs;

    void Awake() {

        if (GameInfo.autoRef) {
            gi = GameInfo.autoRef;
            gi.p1 = -1;
            gi.p2 = -1;
            gi.p3 = -1;
            gi.p4 = -1;
        } else {
            gi = Instantiate(gameInfoPrefab).GetComponent<GameInfo>();
        }
    }

    void asdsda()
    {

        if (!playing)
        {
            foreach (AudioSource a in GetComponents<AudioSource>())
            {
                a.Play();
            }
            audio.mute = true;
            audio.Stop();
            playing = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start_P1"))
        {
            asdsda();

            gi.p1 = (gi.p1 + 1) % gi.listPlayerPrefabs.Count;
            if(characterP1) Destroy(characterP1.gameObject);
            characterP1 = Instantiate(characterMenuPrefabs[gi.p1], characterPositionP1.transform.position, Quaternion.identity);
            labelP1.text = "GO!";
        }
        if (Input.GetButtonDown("Start_P2"))
        {
            asdsda();

            gi.p2 = (gi.p2 + 1) % gi.listPlayerPrefabs.Count;
            if (characterP2) Destroy(characterP2.gameObject);
            characterP2 = Instantiate(characterMenuPrefabs[gi.p2], characterPositionP2.transform.position, Quaternion.identity);
            labelP2.text = "GO!";
        }
        if (Input.GetButtonDown("Start_P3"))
        {
            asdsda();

            gi.p3 = (gi.p3 + 1) % gi.listPlayerPrefabs.Count;
            if (characterP3) Destroy(characterP3.gameObject);
            characterP3 = Instantiate(characterMenuPrefabs[gi.p3], characterPositionP3.transform.position, Quaternion.identity);
            labelP3.text = "GO!";
        }
        if (Input.GetButtonDown("Start_P4"))
        {
            asdsda();

            gi.p4 = (gi.p4 + 1) % gi.listPlayerPrefabs.Count;
            if (characterP4) Destroy(characterP4.gameObject);
            characterP4 = Instantiate(characterMenuPrefabs[gi.p4], characterPositionP4.transform.position, Quaternion.identity);
            labelP4.text = "GO!";
        }
        
    }
}
