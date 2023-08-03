using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UI : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject slotMenu;
    public GameObject optionMenu;

    public bool isPause = false;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
        //{
        //    Esc(true);
        //}
        //else if(Input.GetKeyDown(KeyCode.Escape) && isPause && mainMenu.activeSelf)  // ���� Ǯ��
        //{
        //    Esc(false);
        //}

        if((Input.GetKeyDown(KeyCode.Escape) && slotMenu.activeSelf))
        {
            BackBtn();
        }
        else if((Input.GetKeyDown(KeyCode.Escape) && optionMenu.activeSelf))
        {
            BackBtn();
        }
    }

    //void Esc(bool Pause)  //Esc��ư�� ������ ��
    //{
    //    isPause = Pause;
    //    mainMenu.SetActive(Pause);
    //    if (Pause) //���� �ɷ��� �� �ڵ�
    //    {
    //        Time.timeScale = 0f;
    //        BackBtn();
    //    }
    //    else  //���� Ǯ���� �� �ڵ�
    //    {
    //        Debug.Log("���� Ǯ��");
    //        Time.timeScale = 1f;
    //    }
    //}


    public void StartBtn()  //���� ��ư
    {
        mainMenu.SetActive(false);
        slotMenu.SetActive(true);
    }

    public void OptionBtn()  //�ɼ� ��ư
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

     public void EndBtn()
    {

    }


    public void BackBtn()  // �����ִ� ��� �޴��� ���� ���θ޴��� ���ֱ�
    {
        mainMenu.SetActive(true);
        slotMenu.SetActive(false);
        optionMenu.SetActive(false);
    }




}
