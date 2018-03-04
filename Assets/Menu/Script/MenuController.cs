using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    
    public Button[] butttons;

    public uint index = 1;
    public float selectSpeed = 0.1f;

    private float currentTime = 0f;
    private bool incremented = false;

	// Use this for initialization
	void Start () {
        butttons[index].Select();
	}

    private void Update()
    {
        float verticalInput = -Input.GetAxis("Vertical_P1");
        if (!incremented && verticalInput <= -0.9f)
        {
            incremented = true;
            currentTime = selectSpeed;
            index = (index + 2) % 3;
            butttons[index].Select();
        }
        else if (!incremented && verticalInput >= 0.9f)
        {
            incremented = true;
            currentTime = selectSpeed;
            index = (index + 1) % 3;
            butttons[index].Select();
        } else if (Mathf.Abs(verticalInput) <= 0.2)
        {
            incremented = false;
            currentTime = 0f;
        }

        if (incremented)
        {
            currentTime -= selectSpeed * Time.deltaTime;
            if (currentTime <= 0f)
            {
                incremented = false;
            }
        }
        
    }
}
