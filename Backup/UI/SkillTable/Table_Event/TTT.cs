using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTT : MonoBehaviour
{
    // ���� ������ �������� content�� ���Ϳ� �;���

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

        // �ڽ� ������Ʈ�� ��ġ�� �����ɴϴ�.
        Vector2 childPosition = childRectTransform.anchoredPosition;

        // �θ� �г��� ��ġ�� ����մϴ�.
        Vector2 panelPosition = -childPosition;

        // �θ� �г��� ��ġ�� �����մϴ�.
        panelRectTransform.anchoredPosition = panelPosition;

    }
}
