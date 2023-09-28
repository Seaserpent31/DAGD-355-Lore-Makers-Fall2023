using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager_Lauren : MonoBehaviour
{
    public GameObject[] bulletTypes;
    [SerializeField] public int currentWeaponIndex = 0;

    // Types of bullets.
    GameObject bullet;
    GameObject electroBullet;
    GameObject poisonDart;
    GameObject rocket;
    GameObject sniperBullet;
    GameObject speedyBullet;

    void Start()
    {
        for (int i = 0; i < bulletTypes.Length; i++)
        {
            bulletTypes[i].SetActive(i == currentWeaponIndex);
        }
    }

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0)
        {
            SetWeapon(1);
            print("Weapon swapped to: " + currentWeaponIndex);
        }
        else if (scrollInput < 0)
        {
            SetWeapon(-1);
            print("Weapon swapped to: " + currentWeaponIndex);
        }
    }

    void SetWeapon(int direction)
    {
        bulletTypes[currentWeaponIndex].SetActive(false);

        currentWeaponIndex += direction;

        if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = bulletTypes.Length - 1;
        }
        else if (currentWeaponIndex >= bulletTypes.Length)
        {
            currentWeaponIndex = 0;
        }

        bulletTypes[currentWeaponIndex].SetActive(true);
    }
}
