using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponT_UI : MonoBehaviour
{
    public WeaponT_Manager weaponT_Manager;

    public Icon icon;  //무기의 정보를 담은 프리팹



    public void SelectWeapon()
    {
        weaponT_Manager.currentNum = icon.iconNumber;

        weaponT_Manager.weaponNameText.text = icon.iconName;
        weaponT_Manager.weaponDesText.text = icon.iconDes;

      
    } 






}




