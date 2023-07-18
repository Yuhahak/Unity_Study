using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public WeaponT_Manager weaponT_Manager;

    public Image Main_Image;
    public Image Sub_Image;


    private void Update()
    {
        StartCoroutine(WeaponUpdate());
    }


    IEnumerator WeaponUpdate()
    {
        Main_Image.sprite = weaponT_Manager.mainWeaponTable.sprite;
        Sub_Image.sprite = weaponT_Manager.subWeaponTable.sprite;
        yield return new WaitForSeconds(0.1f);
    }

}
