using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
    
    public float timeToLive;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
