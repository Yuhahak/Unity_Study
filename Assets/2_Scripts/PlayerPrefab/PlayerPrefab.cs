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
            Debug.Log("���̺�! prefab");
        }
        else
        {
            Debug.Log("�̸��� �Է����ּ���");
        }

    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            inputName.text = PlayerPrefs.GetString("Name");
            inputLevel.text = PlayerPrefs.GetInt("Level").ToString();
            dropdown.value = PlayerPrefs.GetInt("Age");
            Debug.Log("�ε�! prefab");


        }
        else
        {
            Debug.Log("�����Ͱ� �����ϴ�");
        }
    }

    public void DeleteData()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("������ ���� ����!");
        }
        else
        {
            Debug.Log("������ �����Ͱ� �����ϴ�");
        }
    }
}
