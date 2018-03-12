using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectForMenu : MonoBehaviour {

    public GameObject left;
    public GameObject right;

    public GameObject[] prefabs;

    private List<GameObject> objects = new List<GameObject>();
    private List<Vector3> directions = new List<Vector3>();

    // Use this for initialization
    void Start () {
        StartCoroutine(cor());
    }
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < objects.Count; i++){
            if (objects[i]) {
                objects[i].transform.position += directions[i] * Time.deltaTime;
            }
        }
    }

    IEnumerator cor() {
        while (true) {
            int x = Random.Range(-20, 20);
            int y = Random.Range(-50, 50);
            int prefab = Random.Range(0, prefabs.Length);
            GameObject l = Instantiate(prefabs[prefab], left.transform.position + new Vector3(0, x, y), Quaternion.identity);
            l.AddComponent<Rotater>();
            Destroy(l, 20f);
            objects.Add(l);
            directions.Add(new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20)));
            int x2 = Random.Range(-20, 20);
            int y2 = Random.Range(-50, 50);
            int prefab2 = Random.Range(0, prefabs.Length);
            GameObject l2 = Instantiate(prefabs[prefab2], right.transform.position + new Vector3(0, x2, y2), Quaternion.identity);
            l2.AddComponent<Rotater>();
            Destroy(l2, 20f);
            objects.Add(l2);
            directions.Add(new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20)));
            yield return new WaitForSeconds(0.4f);
        }
    }
}
