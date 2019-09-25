using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float fovOnZoom = 30f;
    [SerializeField] float defaultFOV = 60f;
    [SerializeField] float zoomedInSensitivity = .5f;
    [SerializeField] float zoomedOutSensitivity = 2f;
    [SerializeField] Camera cam;
    [SerializeField] RigidbodyFirstPersonController fpsController;

    private void Awake()
    {
        if (!fpsController)
        {
            fpsController = FindObjectOfType<PlayerHealth>().GetComponent<RigidbodyFirstPersonController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
            fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
            cam.fieldOfView = fovOnZoom;
        }
        else
        {
            fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
            cam.fieldOfView = defaultFOV;
        }
    }
}
