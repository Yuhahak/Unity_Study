using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StatIconEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject IconDes;
    public Icon icon;

    //public GameObject UpdateText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        IconDes.gameObject.SetActive(true);
        switch (icon.IconName)
        {
            case "Health":
                IconManager.Instance.IconNameText.text += "체력 + 1";
                break;
            case "Speed":
                IconManager.Instance.IconNameText.text += "이속 + 1";
                break;
            case "Attack":
                IconManager.Instance.IconNameText.text += "공격력 + 1";
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IconDes.gameObject.SetActive(false);
        IconManager.Instance.IconNameText.text = "";
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    UpdateText.gameObject.SetActive(true);
    //}


}
