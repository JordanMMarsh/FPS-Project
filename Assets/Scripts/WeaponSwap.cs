using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [SerializeField] Weapon[] weapons;
    Weapon currentWeapon;
    AmmoManager ammoManager;
    int weaponIndex = 0;

    private void Awake()
    {
        ammoManager = GetComponent<AmmoManager>();
        currentWeapon = weapons[weaponIndex];
        for (var i = 0; i < weapons.Length; i++)
        {
            if (i != 0)
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }

    private void Start()
    {
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
        ammoManager.UpdateAmmoText();
    }

    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public Weapon[] GetWeapons()
    {
        return weapons;
    }
}
