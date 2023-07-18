using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabUI : MonoBehaviour
{
    [Header("Tab UI")]
    public GameObject tabPanel; //�� �г�

    public List<GameObject> tabPanelList = new List<GameObject>(); //�� �гθ޴� ����Ʈ
    public List<Button> tabPanelBtnList = new List<Button>(); //�� �гι�ư ����Ʈ
    // 0: ����â , 1: ��ųâ , 2: �� , 3: �������, 4: ����

    public Button statusBtn_Sel; //�ʱ� ���ù�ư

    public bool isTabPause = false;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TabBtn();
            StartCoroutine(SetTabBtn());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscBtn();
        }

    }

    public void TabPause()  //�� ����
    {
        tabPanel.gameObject.SetActive(true);
        tabPanelList[0].gameObject.SetActive(true);
        Time.timeScale = 0f;
        isTabPause = true;
        GameManager.instance.isTabPanelOpen = true;
        statusBtn_Sel.Select();
    }

    public void TabResume() //���
    {
        statusBtn_Sel.Select();
        tabPanel.gameObject.SetActive(false);
        for(int i = 0; i < tabPanelList.Count; i++)
        {
            tabPanelList[i].gameObject.SetActive(false); //��� �� ����
        }
        Time.timeScale = 1f;
        isTabPause = false;
        GameManager.instance.isTabPanelOpen = false;
    }

    #region Tab ���

    public void ShowTabPanel(int index)  //�ش� �ε����� �� �г� �����ֱ�
    {
        for (int i = 0; i < tabPanelList.Count; i++)
        {
            tabPanelList[i].SetActive(i == index);
        }
    }

    public void StatusBtn()  //�ɷ�â ��ư
    {
        ShowTabPanel(0);
    }

    public void SkillBtn()  //��ųâ ��ư
    {
        ShowTabPanel(1);
    }

    public void MapBtn()  //�� ��ư
    {
        ShowTabPanel(2);
    }

    public void MemoryBtn()  //������� ��ư
    {
        ShowTabPanel(3);
    }

    public void WeaponBtn()  //����â ��ư
    {
        ShowTabPanel(4);
    }

    #endregion


    void TabBtn()  //Tab��ư
    {

        if (!isTabPause && !GameManager.instance.isEscPanelOpen)
        {
            TabPause();
        }
        else
        {
            TabResume();
        }
    }

    void EscBtn()  //ESC��ư
    {
        if (isTabPause)
        {
            TabResume();
        }
    }

    IEnumerator SetTabBtn() // ���콺 Ŭ������ �� ��ư Select����
    {
        while (isTabPause)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)
                || Input.GetKeyDown(KeyCode.Mouse2))
            {
                ActiveTabPanel(tabPanelList);
            }
            else if (!tabPanelList[1].activeSelf)
            {
                IconManager.Instance.iconNameText.text = "";
            }
            yield return null;
        }
    }

    private void ActiveTabPanel(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].activeSelf)
            {
                EventSystem.current.SetSelectedGameObject(tabPanelBtnList[i].gameObject);
                break;
            }
        }
    }

}
