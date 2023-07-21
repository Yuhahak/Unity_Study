using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayData
{
    public string name = "������";
    public int playerLevel = 2;
    public int str = 33;


}


public class TestJ : MonoBehaviour
{

    public PlayData playData = new PlayData(); // �÷��̾� ������ ����


    private string path;
    private string Data;


    public InputField nameText;
    public InputField levelText;
    public InputField strText;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/playerSave.json";    // ��� ����

        if (File.Exists(path))
        {
            LoadPlayData();


        }
        else
        {
            Debug.Log("�ҷ��� ������ �����ϴ�");
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Data);

    }

    public void SavePlayData()
    {
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (!string.IsNullOrEmpty(nameText.text) &&
                !string.IsNullOrEmpty(levelText.text) &&
                !string.IsNullOrEmpty(strText.text))
            {
                playData.name = nameText.text;
                playData.playerLevel = int.Parse(levelText.text);
                playData.str = int.Parse(strText.text);


                Data = JsonUtility.ToJson(playData);
                File.WriteAllText(path, Data);
                Debug.Log("���̺�");
            }
                
        }
    }

    public void LoadPlayData()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (File.Exists(path))
            {
                Data = File.ReadAllText(path);
                playData = JsonUtility.FromJson<PlayData>(Data);

                nameText.text = playData.name;
                levelText.text = playData.playerLevel.ToString();
                strText.text = playData.str.ToString();
                Debug.Log("���� �ε�");
            }
            else
            {
                Debug.Log("�ҷ��� ������ �����ϴ�");
            }



        }
    }

    public void DeleteData()
    {
        File.Delete(path);
        Debug.Log("������ ����");
    }
}
