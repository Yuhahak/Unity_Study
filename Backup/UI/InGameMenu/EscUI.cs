using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class EscUI : MonoBehaviour
{
    public GameObject tabPanel; //탭 패널
    public List<GameObject> escPanelList = new List<GameObject>(); // esc패널 리스트
    // 0: 퍼즈패널, 1: 옵션패널, 2: 세이브 패널

    public List<Button> escPanelBtnList = new List<Button>(); //esc버튼 리스트
    // 0: 계속하기, 1: 세이브, 2: 옵션, 3: 타이틀로, 4: 게임종료


    private bool isPause = false;

    [Header("Btn")]
    public Button ContinueBtn_Sel; //초기 선택버튼
    public Button GamePlayBtn_Sel; //초기 선택버튼

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(EscBtn());
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(TabBtn());
        }
    }



    public void Pause() //퍼즈
    {
        escPanelList[0].gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
        GameManager.instance.isEscPanelOpen = true;
        ContinueBtn_Sel.Select();
    }

    public void Resume() //계속
    {
        ContinueBtn_Sel.Select();
        escPanelList[0].gameObject.SetActive(false);
        escPanelList[1].gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
        GameManager.instance.isEscPanelOpen = false;
    }

    #region ESC목록

    public void ContinueBtn() //계속하기 버튼
    {
        Resume();
    }

    public void OptionBtn() //옵션버튼
    {
        escPanelList[0].gameObject.SetActive(false);
        escPanelList[1].gameObject.SetActive(true);
        GamePlayBtn_Sel.Select();
    }


    public void SaveCallBtn()  //세이브 불러오기 버튼
    {

    }

    public void TitleBtn()  //타이틀로 버튼
    {

    }
    #endregion


    IEnumerator EscBtn()  //Esc버튼
    {

        if (!isPause && !GameManager.instance.isTabPanelOpen)
        {
            Pause();
        }
        else if (escPanelList[1].activeSelf)
        {
            escPanelList[1].gameObject.SetActive(false);
            Pause();
        }
        else
        {
            Resume();
        }

        if (isPause)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Resume();
                tabPanel.SetActive(true);
            }
        }

        yield return null;
    }

    IEnumerator TabBtn()
    {
        if (isPause)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Resume();
                tabPanel.SetActive(true);
            }
        }
        yield return null;
    }
}
