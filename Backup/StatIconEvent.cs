using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatIconEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public IconManager iconManager;
    public GameObject IconDes;
    public Icon icon;


    public void OnPointerEnter(PointerEventData eventData)  //���콺�� �����ܿ� ����� ��
    {
        IconDes.gameObject.SetActive(true);
        iconManager.IconNameText.text += icon.iconName + " + 1";
    }

    public void OnPointerExit(PointerEventData eventData)  //���콺�� �����ܿ��� ������ ��
    {
        IconDes.gameObject.SetActive(false);
        iconManager.IconNameText.text = "";
    }

}
