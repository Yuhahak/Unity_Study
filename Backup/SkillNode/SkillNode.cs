using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNode : MonoBehaviour
{
    public string SkillName;
    public Sprite SkillSprite;

    [TextArea(1, 3)]
    public string SkillDes;
    public SkillNode[] SkillNodes;
    public bool isActvie;
    public bool isUpgrade;
}
