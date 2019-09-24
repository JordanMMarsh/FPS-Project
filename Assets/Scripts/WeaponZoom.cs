using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float fovOnZoom = 30f;
    [SerializeField] float defaultFOV = 60f;
    [SerializeField] Camera cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            cam.fieldOfView = fovOnZoom;
        }
        else
        {
            cam.fieldOfView = defaultFOV;
        }
    }
}
