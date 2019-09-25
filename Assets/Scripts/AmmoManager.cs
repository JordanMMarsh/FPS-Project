using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] int startingAmmo = 10;
    [SerializeField] TextMeshProUGUI ammoText;
    Weapon[] weapons;
    WeaponSwap weaponSwap;
    Dictionary<AmmoType, int> weaponDictionary = new Dictionary<AmmoType, int>();

    private void Awake()
    {
        weaponSwap = GetComponent<WeaponSwap>();
        weapons = weaponSwap.GetWeapons();
        for (var i = 0; i < weapons.Length; i++)
        {
            weaponDictionary.Add(weapons[i].ammoType, startingAmmo);
        }
        
    }

    private void Start()
    {
        UpdateAmmoText();
    }

    private void OnEnable()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        ammoText.text = weaponDictionary[weaponSwap.GetCurrentWeapon().ammoType].ToString();
    }

    public int GetAmmoCount(AmmoType ammoType)
    {
        return weaponDictionary[ammoType];
    }

    public void Fire(AmmoType ammoType)
    {
        weaponDictionary[ammoType] -= 1;
        UpdateAmmoText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            weaponDictionary[other.gameObject.GetComponent<AmmoPickup>().ammoType] += other.gameObject.GetComponent<AmmoPickup>().ammoAmount;
            UpdateAmmoText();
            Destroy(other.gameObject);
        }
    }
}
