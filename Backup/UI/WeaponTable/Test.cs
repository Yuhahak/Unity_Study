using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // icon에 이 무기의 정보가 담긴 프리펩을 담기

    public WeaponT_Manager weaponT_Manager;
    public Icon icon;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            weaponT_Manager.weaponBoolList[icon.iconNumber - 1 ] = true;
            Debug.Log(icon.iconName + "켜짐");
            gameObject.SetActive(false);
        }
    }
}
