using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Line : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("����� �� ������")]
    public Attack[] attack;
    [Header("����� ��")]
    public List<GameObject> line = new List<GameObject>();
    // 0: �ڱ��ڽ� , 1: ���ʺ��� ~~ 


    public void LineClick()
    {
        for (int i = 0; i < attack.Length - 1; i++)
        {
            if (attack[0].isGet && attack[i + 1].isGet)
            {
                line[i].SetActive(true);
            }
        }
    }

    // ================ ������ ������ ä���  ===========

    public Image fillImage; // ä��� �̹���
    private float fillSpeed = 1f; // ä������ �ӵ�
    private float fillAmount; // ���� ä���� ��

    private bool isFilling = false; // ä��� ������ ����
    public bool isFill = false;

    private void Awake()
    {
        fillImage.fillAmount = 0f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (attack[0].skillNodeState == 1)
        {
            StartFill();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopFill();
        ResetFill();
    }

    private void StartFill()
    {
        if (!isFilling)
        {
            isFilling = true;
            StartCoroutine(FillRoutine());
        }
    }

    private void StopFill()
    {
        isFilling = false;
    }

    private IEnumerator FillRoutine()
    {
        while (isFilling)
        {
            fillAmount += fillSpeed * Time.unscaledDeltaTime;
            fillAmount = Mathf.Clamp01(fillAmount);
            fillImage.fillAmount = fillAmount;

            if (fillAmount >= 1f)
            {
                isFill = true;
                StopFill();
            }

            yield return null;
        }
    }

    private void ResetFill()
    {
        fillAmount = 0f;
        fillImage.fillAmount = fillAmount;
    }
}
