using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNodeExam : SkillNodes
{
    public int SkillNodeState; // 스킬상태 0 비활성화, 1 활성화가능, 2 활성화

    private void Start()
    {

    }

    public void TakeState() // 부모객체 딕셔너리 참조 스킬유무 파악 이후 스킬상태 노드에 반영하기 위한 용도 함수
    {
        if (GetDictionary().ContainsKey(this.transform.name))
        {
            SkillNodeState = GetDictionary()[this.transform.name];
        }
        else
        {
            Debug.Log("스킬이 존재하지 않습니다.");
        }
    }
    public void SkillChangeValue() // 스킬 상태 변경시 호출할 함수
    {
        Dictionary<string, int> skillNodes = base.GetDictionary();
        if (skillNodes.ContainsKey(gameObject.name))
        {
            skillNodes[gameObject.name] = SkillNodeState;
        }
        Debug.Log(skillNodes[gameObject.name]);
    }
}
