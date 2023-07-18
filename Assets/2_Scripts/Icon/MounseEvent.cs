using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MounseEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject SkillDesTable;
    public Icon icon;


    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillDesTable.gameObject.SetActive(true);
        switch (icon.IconName)
        {
            case "Fire":
                IconManager.Instance.SkillNameText.text += "Fire";
                IconManager.Instance.SkillDesText.text += "불을 발사한다.";
                break;
            case "Water":
                IconManager.Instance.SkillNameText.text += "Water";
                IconManager.Instance.SkillDesText.text += "물대포~";
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SkillDesTable.gameObject.SetActive(false);
        IconManager.Instance.SkillNameText.text = "";
        IconManager.Instance.SkillDesText.text = "";

    }










    //private void Update()
    //{
    //    if (EventSystem.current.IsPointerOverGameObject())
    //    {
    //        Debug.Log("!");
    //    }
    //}
}
