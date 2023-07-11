using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Line : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Attack attack; // 아이콘 자신

    public Image fillImage; // 채우는 이미지
    private float fillSpeed = 0.75f; // 채워지는 속도
    private float fillAmount; // 현재 채워진 양

    private bool isFilling; // 채우는 중인지 여부
    private float fillInterval = 0.1f; // 채우는 간격 (초 단위)
    public bool isFill = false;

    private void Awake()
    {
        fillImage.fillAmount = 0f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (attack.skillNodeState == 1)
        {
            StartFill();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(StopAndResetFill());
    }

    private void StartFill()
    {
        if (!isFilling)
        {
            InvokeRepeating(nameof(IncreaseFillAmount), 0f, fillInterval);
            isFilling = true;
        }
    }

    private void StopFill()
    {
        if (isFilling)
        {
            CancelInvoke(nameof(IncreaseFillAmount));
            isFilling = false;
        }
    }

    private void IncreaseFillAmount()
    {
        fillAmount += fillSpeed * fillInterval;
        fillAmount = Mathf.Clamp01(fillAmount);
        fillImage.fillAmount = fillAmount;

        if (fillAmount >= 1f)
        {
            isFill = true;
            StopFill();
        }
    }

    private void ResetFill()
    {
        Debug.Log("1");
        fillAmount = 0f;
        fillImage.fillAmount = fillAmount;
    }

    private IEnumerator StopAndResetFill()
    {
        yield return null; // 한 프레임 대기

        if (!attack.isGet)
        {
            StopFill();
            ResetFill();
        }
    }
}