using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatIcon : SkillNodes
{

    //public int SkillNodeState; // ��ų���� 0 ��Ȱ��ȭ, 1 Ȱ��ȭ����, 2 Ȱ��ȭ
    private readonly string statName; // ���� �̸�
    private readonly string statDes; // ���� ����
    public GameObject iconDes; // ���� ����â
    public TMP_Text iconNameText;  // ���� ���� �ؽ�Ʈ

    //public void TakeState() // �θ�ü ��ųʸ� ���� ��ų���� �ľ� ���� ��ų���� ��忡 �ݿ��ϱ� ���� �뵵 �Լ�
    //{
    //    if (GetDictionary().ContainsKey(this.transform.name))
    //    {
    //        SkillNodeState = GetDictionary()[this.transform.name];
    //    }
    //    else
    //    {
    //        Debug.Log("��ų�� �������� �ʽ��ϴ�.");
    //    }
    //}
    //public void SkillChangeValue() // ��ų ���� ����� ȣ���� �Լ�
    //{
    //    Dictionary<string, int> skillNodes = base.GetDictionary();
    //    if (skillNodes.ContainsKey(gameObject.name))
    //    {
    //        skillNodes[gameObject.name] = SkillNodeState;
    //    }
    //    Debug.Log(skillNodes[gameObject.name]);
    //}


    public virtual void IconClick()  //�������� Ŭ������ ��
    {
    }
}
