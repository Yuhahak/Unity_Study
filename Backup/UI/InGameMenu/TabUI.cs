using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabUI : MonoBehaviour
{
    [Header("Tab UI")]
    public GameObject tabPanel; //탭 패널

    public List<GameObject> tabPanelList = new List<GameObject>(); //탭 패널메뉴 리스트
    public List<Button> tabPanelBtnList = new List<Button>(); //탭 패널버튼 리스트
    // 0: 상태창 , 1: 스킬창 , 2: 맵 , 3: 기억조각, 4: 무기

    public Button statusBtn_Sel; //초기 선택버튼

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

    public void TabPause()  //탭 퍼즈
    {
        tabPanel.gameObject.SetActive(true);
        tabPanelList[0].gameObject.SetActive(true);
        Time.timeScale = 0f;
        isTabPause = true;
        GameManager.instance.isTabPanelOpen = true;
        statusBtn_Sel.Select();
    }

    public void TabResume() //계속
    {
        statusBtn_Sel.Select();
        tabPanel.gameObject.SetActive(false);
        for(int i = 0; i < tabPanelList.Count; i++)
        {
            tabPanelList[i].gameObject.SetActive(false); //모든 탭 끄기
        }
        Time.timeScale = 1f;
        isTabPause = false;
        GameManager.instance.isTabPanelOpen = false;
    }

    #region Tab 목록

    public void ShowTabPanel(int index)  //해당 인덱스의 탭 패널 보여주기
    {
        for (int i = 0; i < tabPanelList.Count; i++)
        {
            tabPanelList[i].SetActive(i == index);
        }
    }

    public void StatusBtn()  //능력창 버튼
    {
        ShowTabPanel(0);
    }

    public void SkillBtn()  //스킬창 버튼
    {
        ShowTabPanel(1);
    }

    public void MapBtn()  //맵 버튼
    {
        ShowTabPanel(2);
    }

    public void MemoryBtn()  //기억조각 버튼
    {
        ShowTabPanel(3);
    }

    public void WeaponBtn()  //무기창 버튼
    {
        ShowTabPanel(4);
    }

    #endregion


    void TabBtn()  //Tab버튼
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

    void EscBtn()  //ESC버튼
    {
        if (isTabPause)
        {
            TabResume();
        }
    }

    IEnumerator SetTabBtn() // 마우스 클릭했을 때 버튼 Select고정
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
