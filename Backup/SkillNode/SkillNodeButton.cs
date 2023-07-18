using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillNodeButton : MonoBehaviour
{
    public Text SkillNameText;
    public Text SkillDesText;
    public Image SkillSprite;

    public int buttonId;

    public void PressSkillButton()
    {
        SkillNameText.text = SkillNodeManager.Instance.skills[buttonId].SkillName;
        SkillDesText.text = SkillNodeManager.Instance.skills[buttonId].SkillDes;
        SkillSprite.sprite = SkillNodeManager.Instance.skills[buttonId].SkillSprite;

        Debug.Log(buttonId);

    }
}
