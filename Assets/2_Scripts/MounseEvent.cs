using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MounseEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject SkillDesTable;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillDesTable.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SkillDesTable.gameObject.SetActive(false);

    }










    //private void Update()
    //{
    //    if (EventSystem.current.IsPointerOverGameObject())
    //    {
    //        Debug.Log("!");
    //    }
    //}
}
