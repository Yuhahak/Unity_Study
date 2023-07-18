using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponT_Manager : MonoBehaviour
{
    public GameObject ga;

    [Header("���� ����Ʈ")]
    public List<Icon> weaponList = new List<Icon>();  // ������ ������ ����Ǿ��ִ� ������
    public List<GameObject> weaponObjList = new List<GameObject>();  //���� Ȱ��ȭ ����Ʈ
    public List<GameObject> weaponObjListNone = new List<GameObject>();  //���� ��Ȱ��ȭ ����Ʈ
    public List<GameObject> weaponObj = new List<GameObject>(); // ���� ������Ʈ ����Ʈ
    // ���� ���
    // 0: 1Weapon, 1: 2Weapon ~ 
    [Header("���� ȹ�� ����")]
    public List<bool> weaponBoolList = new List<bool>();  //���� ȹ�� ���� ����Ʈ

    [HideInInspector] public int currentNum;  //���� ���� �ѹ�

    [Header("����")]
    public TMP_Text weaponNameText;  //���� �̸� �ؽ�Ʈ
    public TMP_Text weaponDesText;  //���� ���� �ؽ�Ʈ

    public Image mainWeaponTable; // ���ι��� ���� â
    public Image subWeaponTable; // ���깫�� ���� â
    public Sprite resetTableImage;  // ����,���깫�� �������� �� �̹���

    public GameObject unEquipTable; //���� ���� �� Ȯ��â
    private bool subBoolEquip = false; //���� ���� ���� ����


    private void OnEnable()
    {
        StartCoroutine(WeaponBool());
    }

    public void Set_MainWeapon()  // ���ι��� ����ư�� ������ ��
    {
        if (weaponNameText.text != "")
        {
            if (mainWeaponTable.sprite != weaponList[currentNum - 1].iconSprite && subWeaponTable.sprite != weaponList[currentNum - 1].iconSprite)  //���� �ڵ�
            {
                Debug.Log(currentNum);
                Debug.Log("���ι��� ����!");
                mainWeaponTable.sprite = weaponList[currentNum - 1].iconSprite;
                ga = weaponList[currentNum - 1].weapon.gameObject;
                GameObject main = PlayerStatus.Instance.GetPlayerWeapon();
                Instantiate(weaponObj[currentNum - 1], main.transform);
            }
            else
            {
                Debug.Log("�̹� ���Ǿ� �ֽ��ϴ�.");
            }
        }
            
    }


    public void Set_SubWeapon()  //���깫�� ����ư�� ������ ��
    {
        if (weaponNameText.text != "")
        {
            if (mainWeaponTable.sprite != weaponList[currentNum - 1].iconSprite && subWeaponTable.sprite != weaponList[currentNum - 1].iconSprite)
            {
                Debug.Log("���깫�� ����!");
                subWeaponTable.sprite = weaponList[currentNum - 1].iconSprite;
                subBoolEquip = true;
                GameObject sub = PlayerStatus.Instance.GetPlayerWeapon();
                Instantiate(weaponObj[currentNum - 1], sub.transform);
            }
            else
            {
                Debug.Log("�̹� ���Ǿ� �ֽ��ϴ�.");
            }
        }
        
    } 


    public void Del_Weapon()  //����â�� ������ �� ��������
    {
        if (subBoolEquip) 
        {
            unEquipTable.SetActive(true);
        }
    }


    public void Del_Weapon_Ok()  // ��
    {
        unEquipTable.SetActive(false);

        if(subBoolEquip)
        {
            subWeaponTable.sprite = resetTableImage;
            subBoolEquip = false;
        }
    }

    public void Del_Weapon_No()  // �ƴϿ�
    {
        unEquipTable.SetActive(false);
        subBoolEquip = true;
    }


    IEnumerator WeaponBool()  // ���� ȹ�� ����
    {
        if (gameObject.activeSelf)
        {
            for(int i =0; i < weaponBoolList.Count; i++)
            {
                if (weaponBoolList[i] == true)
                {
                    weaponObjList[i].SetActive(true);
                    weaponObjListNone[i].SetActive(false);
                }
                else
                {
                    weaponObjList[i].SetActive(false);
                    weaponObjListNone[i].SetActive(true);
                }
            }
        }
        yield return null;
    }

    


}


