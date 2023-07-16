using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Icon")]

public class Icon : ScriptableObject //아이콘의 정보 저장
{
    public string iconName;
    public Sprite iconSprite;
    public string iconDes;
    public int iconNumber;
    public GameObject weapon;


    //public float Damage;   // 무기의 스텟을 담는다
    //public float Amour;
    //public float Speed;

}
