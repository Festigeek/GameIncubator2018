// Coder : Stéphane Blanc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBeltController : MonoBehaviour
{

    public List<GameObject> bodyList;
    public float beltRadius;
    public float beltHeight;
    public float maxSizeAsteroid;
    public int numberAsteroids; 
    private GameObject body;
   

    // Use this for initialization
    void Start()
    {
        SpawnAsteroid();
    }

    public void SpawnAsteroid()
    {
        int k = 0;
        float resize; 

       while (k < numberAsteroids)
        {
            resize = Random.Range(0f, maxSizeAsteroid);

            body = bodyList[Random.Range(0, bodyList.Count)];

            body.transform.localScale = new Vector3(1f, 1f, 1f);
            body.transform.localScale += new Vector3(resize, resize, resize);

            body.transform.position = Random.onUnitSphere * beltRadius;

            if (Mathf.Abs(body.transform.position.y) < beltHeight)
            {
                body.transform.position += new Vector3(Random.Range(-beltHeight, beltHeight), 0, Random.Range(-beltHeight, beltHeight));
                GameObject rock = Instantiate(body, body.transform.position, transform.rotation,transform);
                rock.AddComponent<Rotater>();
                k++;
            }
        }
     
        
    }
}
