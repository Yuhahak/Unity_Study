using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatIcon : SkillNodes
{

    //public int SkillNodeState; // 스킬상태 0 비활성화, 1 활성화가능, 2 활성화
    private readonly string statName; // 스탯 이름
    private readonly string statDes; // 스텟 설명
    public GameObject iconDes; // 스텟 설명창
    public TMP_Text iconNameText;  // 스텟 설명 텍스트

    //public void TakeState() // 부모객체 딕셔너리 참조 스킬유무 파악 이후 스킬상태 노드에 반영하기 위한 용도 함수
    //{
    //    if (GetDictionary().ContainsKey(this.transform.name))
    //    {
    //        SkillNodeState = GetDictionary()[this.transform.name];
    //    }
    //    else
    //    {
    //        Debug.Log("스킬이 존재하지 않습니다.");
    //    }
    //}
    //public void SkillChangeValue() // 스킬 상태 변경시 호출할 함수
    //{
    //    Dictionary<string, int> skillNodes = base.GetDictionary();
    //    if (skillNodes.ContainsKey(gameObject.name))
    //    {
    //        skillNodes[gameObject.name] = SkillNodeState;
    //    }
    //    Debug.Log(skillNodes[gameObject.name]);
    //}


    public virtual void IconClick()  //아이콘을 클릭했을 때
    {
    }
}
