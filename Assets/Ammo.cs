using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int startingAmmo = 10;
    int ammo;

    private void Start()
    {
        ammo = startingAmmo;
    }

    public int GetAmmoCount()
    {
        return ammo;
    }

    public void UseAmmo(int bullets)
    {
        ammo -= bullets;
        if (ammo < 0) { ammo = 0; }
    }
}
