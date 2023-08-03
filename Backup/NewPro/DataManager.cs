using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData
{
    // 이름, 레벨, 코인, 착용중인 무기
    public string name;
    public int level = 1;
    public int coin = 100;
}

public class OptionData  // 게임의 총 데이터 / 사운드, 그래픽 등 옵션 / 기본 옵션이 될 정보를 저장해주기
{
    // 사운드
    public float bgm_vol = 1.0f;  // 배경음 볼륨
    public float sfx_vol = 1.0f;  // 효과음 볼륨
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance; // 싱글톤패턴

    public PlayerData playerData = new PlayerData(); // 플레이어 데이터 생성
    public OptionData optionData = new OptionData(); // 옵션 데이터 생성

    public Sound sound;

    public string path; // 경로
    public int nowSlot; // 현재 슬롯번호

    private void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Application.persistentDataPath + "/save";	// 경로 지정
        print(path);

        if (PlayerPrefs.HasKey("Bgm"))
        {
            LoadPrefs();
        }
        else
        {
            Debug.Log("잉");
        }

        //if(File.Exists(path + "optionData" + ".Json"))  // 게임실행했을 때 옵션데이터가 있으면 불러오기
        //{
        //    OptionLoadData();
        //}
        //else  // 없으면 기본 옵션 데이터를 저장
        //{
        //    OptionSaveData();
        //}
    }

    public void SaveData()
    {
        Debug.Log("데이터세이브");
        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(path + nowSlot.ToString() + ".Json", data);
    }

    public void LoadData()
    {
        Debug.Log("데이터로드");
        string data = File.ReadAllText(path + nowSlot.ToString() + ".Json");
        playerData = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        playerData = new PlayerData();
    }

    public void SavePrefs() //PlayerPrefs에 적용할 것들
    {
        PlayerPrefs.SetFloat("Bgm", sound.bgm_slider.value);
        PlayerPrefs.SetFloat("Sfx", sound.sfx_slider.value);
    }

    public void LoadPrefs()
    {
        if (PlayerPrefs.HasKey("Bgm"))
        {
            sound.bgm_slider.value = PlayerPrefs.GetFloat("Bgm");
            sound.sfx_slider.value = PlayerPrefs.GetFloat("Sfx");
        }
    }


    //public void OptionSaveData()
    //{
    //    Debug.Log("옵션세이브");
    //    string option = JsonUtility.ToJson(optionData);
    //    File.WriteAllText(path + "optionData" + ".Json", option);
    //}

    //public void OptionLoadData()
    //{
    //    Debug.Log("옵션로드");
    //    string option = File.ReadAllText(path + "optionData" + ".Json");
    //    optionData = JsonUtility.FromJson<OptionData>(option);
    //    OnOption();
    //}


    //public void OnOption() // json 파일에 정보를 옵션에 적용
    //{
    //    sound.bgm_slider.value = optionData.bgm_vol;
    //    sound.sfx_slider.value = optionData.sfx_vol;
    //}





}
