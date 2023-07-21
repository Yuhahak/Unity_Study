using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayData
{
    public string name = "무재학";
    public int playerLevel = 2;
    public int str = 33;


}


public class TestJ : MonoBehaviour
{

    public PlayData playData = new PlayData(); // 플레이어 데이터 생성


    private string path;
    private string Data;


    public InputField nameText;
    public InputField levelText;
    public InputField strText;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/playerSave.json";    // 경로 지정

        if (File.Exists(path))
        {
            LoadPlayData();


        }
        else
        {
            Debug.Log("불러올 파일이 없습니다");
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
                Debug.Log("세이브");
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
                Debug.Log("파일 로드");
            }
            else
            {
                Debug.Log("불러올 파일이 없습니다");
            }



        }
    }

    public void DeleteData()
    {
        File.Delete(path);
        Debug.Log("데이터 삭제");
    }
}
