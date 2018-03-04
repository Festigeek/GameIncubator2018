using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDestruction : MonoBehaviour {

	public List<GameObject> parts;
	public List<GameObject> objects;

	private bool isDestroyed = false;
    private bool isRealyDestroyed = false;
    private bool looted = false;
	private static Random rnd;
	private Vector3 cratePosition;
	private Quaternion crateRotation;

	// Use this for initialization
	void Start () {
		rnd = new Random(); 


	}

	// Update is called once per frame
	void Update () {
		cratePosition = transform.position;
		crateRotation = transform.rotation;

		if (isDestroyed) {
			// destruction of crate
			foreach (GameObject g in parts) {
                if (g)
                {
                    if (g.GetComponent<Rigidbody>() == null)
                    {
                        g.AddComponent<Rigidbody>();
                        g.AddComponent<BoxCollider>();
                    }
                    
                    if (!isRealyDestroyed)
                    {
                        Destroy(g, Random.Range(2, 5));
                        isRealyDestroyed = true;
                    }
                }
			}
            //makeLootAppear();
            Destroy(this, 5);
		}
	}

	// TODO : make loot appear in correct position/rotation
	private void makeLootAppear()
	{
		if (!looted) {
			// a random object appears at the crate emplacement
			GameObject loot = objects[Random.Range(0, objects.Count)];
			Instantiate(loot, cratePosition, loot.transform.rotation);
			looted = true;
		}

	}

	public void destroyCrate()
	{
		isDestroyed = true;
	}
}
