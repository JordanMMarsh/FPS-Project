using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [SerializeField] Weapon[] weapons;
    Weapon currentWeapon;
    int weaponIndex = 0;

    private void Start()
    {
        currentWeapon = weapons[weaponIndex];
        SwapWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Swap Weapon"))
        {
            if (weaponIndex < weapons.Length - 1)
            {
                weaponIndex++;
                SwapWeapons();
            }
            else
            {
                weaponIndex = 0;
                SwapWeapons();
            }
        }
    }

    private void SwapWeapons()
    {
        currentWeapon.SwapWeapon();
        currentWeapon.gameObject.SetActive(false);
        currentWeapon = weapons[weaponIndex];
        currentWeapon.gameObject.SetActive(true);
    }
}
