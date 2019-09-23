using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject terrainHitFX;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyHealth>().DealDamage(damage);
            }
            else
            {
                CreateHitFX(hit);
            }
        }
    }

    private void CreateHitFX(RaycastHit hit)
    {
        GameObject hitFX = Instantiate(terrainHitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitFX, .2f);
    }
}
