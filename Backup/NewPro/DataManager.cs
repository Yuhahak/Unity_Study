using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData
{
    // �̸�, ����, ����, �������� ����
    public string name;
    public int level = 1;
    public int coin = 100;
}

public class OptionData  // ������ �� ������ / ����, �׷��� �� �ɼ� / �⺻ �ɼ��� �� ������ �������ֱ�
{
    // ����
    public float bgm_vol = 1.0f;  // ����� ����
    public float sfx_vol = 1.0f;  // ȿ���� ����
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance; // �̱�������

    public PlayerData playerData = new PlayerData(); // �÷��̾� ������ ����
    public OptionData optionData = new OptionData(); // �ɼ� ������ ����

    public Sound sound;

    public string path; // ���
    public int nowSlot; // ���� ���Թ�ȣ

    private void Awake()
    {
        #region �̱���
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

        path = Application.persistentDataPath + "/save";	// ��� ����
        print(path);

        if (PlayerPrefs.HasKey("Bgm"))
        {
            LoadPrefs();
        }
        else
        {
            Debug.Log("��");
        }

        //if(File.Exists(path + "optionData" + ".Json"))  // ���ӽ������� �� �ɼǵ����Ͱ� ������ �ҷ�����
        //{
        //    OptionLoadData();
        //}
        //else  // ������ �⺻ �ɼ� �����͸� ����
        //{
        //    OptionSaveData();
        //}
    }

    public void SaveData()
    {
        Debug.Log("�����ͼ��̺�");
        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(path + nowSlot.ToString() + ".Json", data);
    }

    public void LoadData()
    {
        Debug.Log("�����ͷε�");
        string data = File.ReadAllText(path + nowSlot.ToString() + ".Json");
        playerData = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        playerData = new PlayerData();
    }

    public void SavePrefs() //PlayerPrefs�� ������ �͵�
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
    //    Debug.Log("�ɼǼ��̺�");
    //    string option = JsonUtility.ToJson(optionData);
    //    File.WriteAllText(path + "optionData" + ".Json", option);
    //}

    //public void OptionLoadData()
    //{
    //    Debug.Log("�ɼǷε�");
    //    string option = File.ReadAllText(path + "optionData" + ".Json");
    //    optionData = JsonUtility.FromJson<OptionData>(option);
    //    OnOption();
    //}


    //public void OnOption() // json ���Ͽ� ������ �ɼǿ� ����
    //{
    //    sound.bgm_slider.value = optionData.bgm_vol;
    //    sound.sfx_slider.value = optionData.sfx_vol;
    //}





}
