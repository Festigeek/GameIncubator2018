// Coder : Stéphane Blanc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSkybox : MonoBehaviour {

    public float speedMultiplier;  //addapte la vitesse de rotation


    // Update is called once per frame
    void Update()
    {
        //Sets the float value of "_Rotation", adjust it by Time.time and a multiplier.
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speedMultiplier);
    }
}
