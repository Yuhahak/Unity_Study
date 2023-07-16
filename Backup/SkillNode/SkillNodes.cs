using UnityEngine;
using System.Collections.Generic;

public class SkillNodes : MonoBehaviour
{
    public Dictionary<string, int> skillNodes = new Dictionary<string, int>(); // 스킬 노드 딕셔너리 뒤에 초기값은 저장쪽 만들고 삭제
    public List<KeyValuePair<string, int>> list;
    private void Start()
    {

    }

    public Dictionary<string, int> GetDictionary() // 스킬 변경시 호출하여 전달용 함수
    {
        return skillNodes;
    }

    public List<KeyValuePair<string, int>> ConvertToList()// 플레이어 데이터 저장시 호출하여 변환한 리스트 받아서 저장용 함수
    {
        list = new List<KeyValuePair<string, int>>(skillNodes);
        return list;
    }

    public void ConvertToDic(List<KeyValuePair<string, int>> SkilList) // 리스트 받아서 딕셔너리 변환
    {
        skillNodes = new Dictionary<string, int>();
        foreach (KeyValuePair<string, int> pair in SkilList)
        {
            skillNodes.Add(pair.Key, pair.Value);
        }
    }
}