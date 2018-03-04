using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fusee_controller : MonoBehaviour {

    public float speed = 2f;
    public float timeToLive;
    public float rotateSpeedX;
    public GameObject explosion;
    public CrateDestruction debris;

    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, timeToLive);
        rotateSpeedX = Random.Range(-10.0f, 10.0f);
        //speed = Random.Range(5.0f, 40.0f);
    }

    // Update is called once per frame
    void Update () {
        transform.position += transform.up*speed*Time.deltaTime;
        transform.Rotate(Vector3.left, rotateSpeedX*Time.deltaTime);
	}

    private void OnDestroy()
    {
        explosion.transform.SetParent(null);
        explosion.SetActive(true);
        debris.transform.SetParent(null);
        debris.destroyCrate();
        Destroy(debris.gameObject, 2*timeToLive);
    }

}
