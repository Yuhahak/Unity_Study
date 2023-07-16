using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Line : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("연결된 전 아이콘")]
    public Attack[] attack;
    [Header("연결된 선")]
    public List<GameObject> line = new List<GameObject>();
    // 0: 자기자신 , 1: 왼쪽부터 ~~ 


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

    // ================ 아이콘 프레임 채우기  ===========

    public Image fillImage; // 채우는 이미지
    private float fillSpeed = 1f; // 채워지는 속도
    private float fillAmount; // 현재 채워진 양

    private bool isFilling = false; // 채우는 중인지 여부
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
