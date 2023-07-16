using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;
using TMPro;

public class OptionUI : MonoBehaviour
{
    public List<GameObject> optionPanelList = new List<GameObject>();  // 옵션 패널 리스트




    public TMP_Dropdown resolutionDropdown; //해상도 저장할 드랍다운
    List<Resolution> resolutions = new List<Resolution>(); //모니터가 지원하는 해상도를 저장할 배열


    public void ShowTabPanel(int index)  //해당 인덱스의 탭 패널 보여주기
    {
        for (int i = 0; i < optionPanelList.Count; i++)
        {
            optionPanelList[i].SetActive(i == index);
        }
    }

    public void GamePlayBtn()
    {
        ShowTabPanel(0);

    }


    public void SoundBtn()
    {
        ShowTabPanel(1);

    }


    public void GraphicBtn()
    {
        ShowTabPanel(2);

        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            resolutions.Add(Screen.resolutions[i]);
        }

        resolutionDropdown.options.Clear();
        int optionNum = 0;

        foreach (Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + " X " + item.height + " " + item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropdown.value = optionNum;
            }
            optionNum++;
        }
    }





    public void ControllBtn()
    {
        ShowTabPanel(3);

    }
}
