using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Line : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Attack attack; // ������ �ڽ�

    public Image fillImage; // ä��� �̹���
    private float fillSpeed = 0.75f; // ä������ �ӵ�
    private float fillAmount; // ���� ä���� ��

    private bool isFilling; // ä��� ������ ����
    private float fillInterval = 0.1f; // ä��� ���� (�� ����)
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
        yield return null; // �� ������ ���

        if (!attack.isGet)
        {
            StopFill();
            ResetFill();
        }
    }
}