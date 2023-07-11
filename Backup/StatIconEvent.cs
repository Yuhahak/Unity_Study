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


    public void OnPointerEnter(PointerEventData eventData)  //마우스가 아이콘에 닿았을 때
    {
        IconDes.gameObject.SetActive(true);
        iconManager.IconNameText.text += icon.iconName + " + 1";
    }

    public void OnPointerExit(PointerEventData eventData)  //마우스가 아이콘에서 나왔을 때
    {
        IconDes.gameObject.SetActive(false);
        iconManager.IconNameText.text = "";
    }

}
