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
        //else if(Input.GetKeyDown(KeyCode.Escape) && isPause && mainMenu.activeSelf)  // 퍼즈 풀기
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

    //void Esc(bool Pause)  //Esc버튼을 눌렀을 때
    //{
    //    isPause = Pause;
    //    mainMenu.SetActive(Pause);
    //    if (Pause) //퍼즈 걸렸을 때 코드
    //    {
    //        Time.timeScale = 0f;
    //        BackBtn();
    //    }
    //    else  //퍼즈 풀었을 때 코드
    //    {
    //        Debug.Log("퍼즈 풀림");
    //        Time.timeScale = 1f;
    //    }
    //}


    public void StartBtn()  //시작 버튼
    {
        mainMenu.SetActive(false);
        slotMenu.SetActive(true);
    }

    public void OptionBtn()  //옵션 버튼
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

     public void EndBtn()
    {

    }


    public void BackBtn()  // 켜져있는 모든 메뉴를 끄고 메인메뉴만 켜주기
    {
        mainMenu.SetActive(true);
        slotMenu.SetActive(false);
        optionMenu.SetActive(false);
    }




}
