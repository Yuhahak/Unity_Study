using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class EscUI : MonoBehaviour
{
    public GameObject tabPanel; //�� �г�
    public List<GameObject> escPanelList = new List<GameObject>(); // esc�г� ����Ʈ
    // 0: �����г�, 1: �ɼ��г�, 2: ���̺� �г�

    public List<Button> escPanelBtnList = new List<Button>(); //esc��ư ����Ʈ
    // 0: ����ϱ�, 1: ���̺�, 2: �ɼ�, 3: Ÿ��Ʋ��, 4: ��������


    private bool isPause = false;

    [Header("Btn")]
    public Button ContinueBtn_Sel; //�ʱ� ���ù�ư
    public Button GamePlayBtn_Sel; //�ʱ� ���ù�ư

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



    public void Pause() //����
    {
        escPanelList[0].gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
        GameManager.instance.isEscPanelOpen = true;
        ContinueBtn_Sel.Select();
    }

    public void Resume() //���
    {
        ContinueBtn_Sel.Select();
        escPanelList[0].gameObject.SetActive(false);
        escPanelList[1].gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
        GameManager.instance.isEscPanelOpen = false;
    }

    #region ESC���

    public void ContinueBtn() //����ϱ� ��ư
    {
        Resume();
    }

    public void OptionBtn() //�ɼǹ�ư
    {
        escPanelList[0].gameObject.SetActive(false);
        escPanelList[1].gameObject.SetActive(true);
        GamePlayBtn_Sel.Select();
    }


    public void SaveCallBtn()  //���̺� �ҷ����� ��ư
    {

    }

    public void TitleBtn()  //Ÿ��Ʋ�� ��ư
    {

    }
    #endregion


    IEnumerator EscBtn()  //Esc��ư
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
