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
    [SerializeField] GameObject player;
    AmmoManager ammoManager;
    public AmmoType ammoType;

    [SerializeField] float fireDelay = 1f;
    private bool canShoot = true;
    private bool fireDelayCoroutRunning = false;
    private Coroutine fireDelayCorout;

    private void Start()
    {
        ammoManager = player.GetComponent<AmmoManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
         if (ammoManager.GetAmmoCount(ammoType) > 0 && canShoot)
         {
            canShoot = false;
            fireDelayCorout = StartCoroutine(FireWeapon());
            fireDelayCoroutRunning = true;
         }
        
    }

    public void SwapWeapon()
    {
        if (fireDelayCoroutRunning)
        {
            StopCoroutine(fireDelayCorout);
            fireDelayCoroutRunning = false;
            canShoot = true;
        }            
    }

    IEnumerator FireWeapon()
    {
        ammoManager.Fire(ammoType);
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

        yield return new WaitForSeconds(fireDelay);
        fireDelayCoroutRunning = false;
        canShoot = true;
    }

    private void CreateHitFX(RaycastHit hit)
    {
        GameObject hitFX = Instantiate(terrainHitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitFX, .2f);
    }
}
