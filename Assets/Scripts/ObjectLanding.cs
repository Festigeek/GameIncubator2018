using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLanding : MonoBehaviour {

    public float radius = 2f;
    public float speed = 2;
    public Spawner landingPoint;
    private bool landed = false;
    private void Start()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>().AddTarget(gameObject.transform, radius);
    }
    void FixedUpdate()
    {
        float dist = Vector3.Distance(transform.position, landingPoint.transform.position);
        if (dist > .1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, landingPoint.transform.position, speed * Time.deltaTime);
        }
        else if (landed == false)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManager>().targetGroup.m_Targets.RemoveAll(x => true);
            landed = true;
            landingPoint.SpawnObjects();
            GetComponentInChildren<Animator>().SetBool("landed", true);
            GetComponentInChildren<ParticleSystem>().Stop();
            GetComponentInChildren<AudioSource>().Stop();
        }

    }
}
