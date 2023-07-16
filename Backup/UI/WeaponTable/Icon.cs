using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Icon")]

public class Icon : ScriptableObject //�������� ���� ����
{
    public string iconName;
    public Sprite iconSprite;
    public string iconDes;
    public int iconNumber;
    public GameObject weapon;


    //public float Damage;   // ������ ������ ��´�
    //public float Amour;
    //public float Speed;

}
