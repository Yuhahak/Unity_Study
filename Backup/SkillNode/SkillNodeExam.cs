using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNodeExam : SkillNodes
{
    public int SkillNodeState; // ��ų���� 0 ��Ȱ��ȭ, 1 Ȱ��ȭ����, 2 Ȱ��ȭ

    private void Start()
    {

    }

    public void TakeState() // �θ�ü ��ųʸ� ���� ��ų���� �ľ� ���� ��ų���� ��忡 �ݿ��ϱ� ���� �뵵 �Լ�
    {
        if (GetDictionary().ContainsKey(this.transform.name))
        {
            SkillNodeState = GetDictionary()[this.transform.name];
        }
        else
        {
            Debug.Log("��ų�� �������� �ʽ��ϴ�.");
        }
    }
    public void SkillChangeValue() // ��ų ���� ����� ȣ���� �Լ�
    {
        Dictionary<string, int> skillNodes = base.GetDictionary();
        if (skillNodes.ContainsKey(gameObject.name))
        {
            skillNodes[gameObject.name] = SkillNodeState;
        }
        Debug.Log(skillNodes[gameObject.name]);
    }
}
