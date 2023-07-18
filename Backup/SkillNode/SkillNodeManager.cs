using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillNodeManager : MonoBehaviour
{
    public static SkillNodeManager Instance;

    public SkillNode[] skills;
    public SkillNodeButton[] skillButtons;


    public Text remainPointText;
    public Text totalPointText;

    public float remainPoints = 9f;
    public float totalPoints = 20f;

    public Sprite upgradeSprite;
    public Sprite normalSprite;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance == this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
    }

    private void Update()
    {
        remainPointText.text = remainPoints.ToString();
        totalPointText.text = totalPoints.ToString();
    }

    public void DisplayPoint()
    {
        totalPointText.text = remainPoints + "/11";
    }


    public void PressUpgrade()
    {
        Debug.Log("upgrade");
        if (remainPoints >= 1)
        {
            Debug.Log("up!");
            remainPoints -= 1;
        }
        else
        {
            Debug.Log("not");
        }
        DisplayPoint();
        UpdateSkillButton();
    }

    void UpdateSkillButton()
    {
        for(int i = 0; i < skills.Length; i++)
        {
            if (skills[i].isUpgrade == true)
            {
                skills[i].GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
                skills[i].transform.GetChild(0).GetComponent<Image>().sprite = upgradeSprite;
            }
            else
            {
                skills[i].GetComponent<Image>().color = new Vector4(0.15f, 0.45f, 0.45f, 1);
                skills[i].transform.GetChild(0).GetComponent<Image>().sprite = normalSprite;
            }
        }
    }


}
