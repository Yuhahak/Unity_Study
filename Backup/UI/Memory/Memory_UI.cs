using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Memory_UI : MonoBehaviour
{
    public Memory_Manager memory_Manager;

    public string Name;
    [Multiline(4)]
    public string Des;

    public void Memory_Btn()
    {
        MemoryText();
    }

    public void MemoryPlay_Btn()
    {
        Debug.Log("@");
    }


    void MemoryText()
    {
        memory_Manager.memory_Name.text = "";
        memory_Manager.memory_Name.text += Name;

        memory_Manager.memory_Des.text = "";
        memory_Manager.memory_Des.text = Des;
    }
}
