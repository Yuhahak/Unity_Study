using UnityEngine;
using System.Collections.Generic;

public class SkillNodes : MonoBehaviour
{
    public Dictionary<string, int> skillNodes = new Dictionary<string, int>(); // ��ų ��� ��ųʸ� �ڿ� �ʱⰪ�� ������ ����� ����
    public List<KeyValuePair<string, int>> list;
    private void Start()
    {

    }

    public Dictionary<string, int> GetDictionary() // ��ų ����� ȣ���Ͽ� ���޿� �Լ�
    {
        return skillNodes;
    }

    public List<KeyValuePair<string, int>> ConvertToList()// �÷��̾� ������ ����� ȣ���Ͽ� ��ȯ�� ����Ʈ �޾Ƽ� ����� �Լ�
    {
        list = new List<KeyValuePair<string, int>>(skillNodes);
        return list;
    }

    public void ConvertToDic(List<KeyValuePair<string, int>> SkilList) // ����Ʈ �޾Ƽ� ��ųʸ� ��ȯ
    {
        skillNodes = new Dictionary<string, int>();
        foreach (KeyValuePair<string, int> pair in SkilList)
        {
            skillNodes.Add(pair.Key, pair.Value);
        }
    }
}