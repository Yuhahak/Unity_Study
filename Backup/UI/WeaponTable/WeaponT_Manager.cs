using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponT_Manager : MonoBehaviour
{
    public GameObject ga;

    [Header("무기 리스트")]
    public List<Icon> weaponList = new List<Icon>();  // 무기의 정보가 저장되어있는 프리펩
    public List<GameObject> weaponObjList = new List<GameObject>();  //무기 활성화 리스트
    public List<GameObject> weaponObjListNone = new List<GameObject>();  //무기 비활성화 리스트
    public List<GameObject> weaponObj = new List<GameObject>(); // 무기 오브젝트 리스트
    // 무기 목록
    // 0: 1Weapon, 1: 2Weapon ~ 
    [Header("무기 획득 여부")]
    public List<bool> weaponBoolList = new List<bool>();  //무기 획득 여부 리스트

    [HideInInspector] public int currentNum;  //현재 무기 넘버

    [Header("참조")]
    public TMP_Text weaponNameText;  //무기 이름 텍스트
    public TMP_Text weaponDesText;  //무기 설명 텍스트

    public Image mainWeaponTable; // 메인무기 장착 창
    public Image subWeaponTable; // 서브무기 장착 창
    public Sprite resetTableImage;  // 메인,서브무기 장착해제 시 이미지

    public GameObject unEquipTable; //무기 해제 시 확인창
    private bool subBoolEquip = false; //서브 무기 장착 여부


    private void OnEnable()
    {
        StartCoroutine(WeaponBool());
    }

    public void Set_MainWeapon()  // 메인무기 장비버튼을 눌렀을 때
    {
        if (weaponNameText.text != "")
        {
            if (mainWeaponTable.sprite != weaponList[currentNum - 1].iconSprite && subWeaponTable.sprite != weaponList[currentNum - 1].iconSprite)  //장착 코드
            {
                Debug.Log(currentNum);
                Debug.Log("메인무기 장착!");
                mainWeaponTable.sprite = weaponList[currentNum - 1].iconSprite;
                ga = weaponList[currentNum - 1].weapon.gameObject;
                GameObject main = PlayerStatus.Instance.GetPlayerWeapon();
                Instantiate(weaponObj[currentNum - 1], main.transform);
            }
            else
            {
                Debug.Log("이미 장비되어 있습니다.");
            }
        }
            
    }


    public void Set_SubWeapon()  //서브무기 장비버튼을 눌렀을 때
    {
        if (weaponNameText.text != "")
        {
            if (mainWeaponTable.sprite != weaponList[currentNum - 1].iconSprite && subWeaponTable.sprite != weaponList[currentNum - 1].iconSprite)
            {
                Debug.Log("서브무기 장착!");
                subWeaponTable.sprite = weaponList[currentNum - 1].iconSprite;
                subBoolEquip = true;
                GameObject sub = PlayerStatus.Instance.GetPlayerWeapon();
                Instantiate(weaponObj[currentNum - 1], sub.transform);
            }
            else
            {
                Debug.Log("이미 장비되어 있습니다.");
            }
        }
        
    } 


    public void Del_Weapon()  //무기창을 눌렀을 때 장착해제
    {
        if (subBoolEquip) 
        {
            unEquipTable.SetActive(true);
        }
    }


    public void Del_Weapon_Ok()  // 네
    {
        unEquipTable.SetActive(false);

        if(subBoolEquip)
        {
            subWeaponTable.sprite = resetTableImage;
            subBoolEquip = false;
        }
    }

    public void Del_Weapon_No()  // 아니요
    {
        unEquipTable.SetActive(false);
        subBoolEquip = true;
    }


    IEnumerator WeaponBool()  // 무기 획득 여부
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


