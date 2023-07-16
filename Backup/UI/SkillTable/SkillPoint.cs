using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillPoint : MonoBehaviour
{
    public int SP; // 스킬포인트
    public TMP_Text SP_Text; //스킬 포인트 표기 텍스트


    private void Update()
    {
        StartCoroutine(SetSP());
    }

    IEnumerator SetSP()
    {
        SP_Text.text = SP.ToString();
        yield return new WaitForSeconds(0.1f);
    }
}
