using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillPoint : MonoBehaviour
{
    public int SP; // ��ų����Ʈ
    public TMP_Text SP_Text; //��ų ����Ʈ ǥ�� �ؽ�Ʈ


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
