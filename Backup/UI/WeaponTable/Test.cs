using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // icon�� �� ������ ������ ��� �������� ���

    public WeaponT_Manager weaponT_Manager;
    public Icon icon;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            weaponT_Manager.weaponBoolList[icon.iconNumber - 1 ] = true;
            Debug.Log(icon.iconName + "����");
            gameObject.SetActive(false);
        }
    }
}
