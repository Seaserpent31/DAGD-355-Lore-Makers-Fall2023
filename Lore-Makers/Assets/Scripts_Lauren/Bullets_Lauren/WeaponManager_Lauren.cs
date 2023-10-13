using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager_Lauren : MonoBehaviour
{
    private GameManager gameManager;

    private int numWeapons;
    public int curWeaponIndex;

    public GameObject[] weapons;
    public GameObject holder;
    public GameObject currentWeapon;

    void Start()
    {
        numWeapons = holder.transform.childCount;
        weapons = new GameObject[numWeapons];

        for (int i = 0; i < numWeapons; i++)
        {
            weapons[i] = holder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);

        }

        // Setting only the first weapon (Bullet) active.
        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
        curWeaponIndex = 0;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (curWeaponIndex < numWeapons -1)
            {
                weapons[curWeaponIndex].SetActive(false);
                curWeaponIndex += 1;
                weapons[curWeaponIndex].SetActive(true);
                currentWeapon = weapons[curWeaponIndex];

                print(curWeaponIndex);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(curWeaponIndex > 0)
            {
                weapons[curWeaponIndex].SetActive(false);
                curWeaponIndex -= 1;
                weapons[curWeaponIndex].SetActive(true);
                currentWeapon = weapons[curWeaponIndex];

                print(curWeaponIndex);
            }

        }

    }

}
