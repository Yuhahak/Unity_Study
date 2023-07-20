using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefab : MonoBehaviour
{
    public Dropdown dropdown;
    public InputField inputName;
    public InputField inputLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save()
    {
        if (inputName != null)
        {
            PlayerPrefs.SetString("Name", inputName.text);
            PlayerPrefs.SetInt("Level", int.Parse(inputLevel.text));
            PlayerPrefs.SetInt("Age", dropdown.value);
            Debug.Log("세이브! prefab");
        }
        else
        {
            Debug.Log("이름을 입력해주세요");
        }

    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            inputName.text = PlayerPrefs.GetString("Name");
            inputLevel.text = PlayerPrefs.GetInt("Level").ToString();
            dropdown.value = PlayerPrefs.GetInt("Age");
            Debug.Log("로드! prefab");


        }
        else
        {
            Debug.Log("데이터가 없습니다");
        }
    }

    public void DeleteData()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("데이터 전부 삭제!");
        }
        else
        {
            Debug.Log("삭제할 데이터가 없습니다");
        }
    }
}
