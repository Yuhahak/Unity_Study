using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTT : MonoBehaviour
{
    // 내가 선택한 아이콘이 content에 센터에 와야함

    public RectTransform panelRectTransform;
    public RectTransform panelRectTransform1;
    public RectTransform childRectTransform;

    public static TTT instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        if (childRectTransform != null)
        {
            CenterPanelToChild();
        }
    }

    private void CenterPanelToChild()
    {
        Debug.Log("Centering panel to child");

        // 자식 오브젝트의 위치를 가져옵니다.
        Vector2 childPosition = childRectTransform.anchoredPosition;

        // 부모 패널의 위치를 계산합니다.
        Vector2 panelPosition = -childPosition;

        // 부모 패널의 위치를 설정합니다.
        panelRectTransform.anchoredPosition = panelPosition;

    }
}
