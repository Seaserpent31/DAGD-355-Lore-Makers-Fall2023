using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager_Lauren : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    private int currentWeapon = 0;

    // Define an enum for weapon types.
    public enum WeaponType
    {
        Bullet,
        Electro,
        PoisonDart,
        Rocket,
        Sniper,
        Speedy
    }

    // Swap to the specified weapon.
    public void SwapWeapon(WeaponType newWeapon)
    {
        int newWeaponIndex = (int)newWeapon;
        if (newWeaponIndex >= 0 && newWeaponIndex < bulletPrefabs.Length)
        {
            currentWeapon = newWeaponIndex;
        }
    }

    // Get the current bullet prefab.
    public GameObject GetCurrentBulletPrefab()
    {
        return bulletPrefabs[currentWeapon];
    }

}
