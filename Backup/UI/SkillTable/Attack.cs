using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Attack : StatIcon, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Reference")]
    public SkillPoint skillPoint;  // Skill_Panel
    private Line line;

    [Header("Info")]
    public int skillNodeState;  // 스킬상태 0 비활성화, 1 활성화가능, 2 활성화
    public string statName;  // 스텟 이름
    [Multiline(3)]
    public string statDes;  //스텟 설명
    public int needSP;  // 필요한 스킬포인트
    [Space(10f)]
    public Sprite canSkill; // 스킬을 찍을 수 있을 때 켜줄 이미지
    public Sprite onSkill; // 스킬이 찍혔을 때 켜줄 이미지

    [Header("Info_Private")]
    public bool isGet = false; //스킬이 켜졌는지 여부
    private Image iconImage;  // 현재 아이콘 이미지
    private RectTransform pos;


    [Header("Next Icon")] // 다음 켜줄 아이콘
    public Attack[] nextIcons;  // 아이콘들의 Attck 스크립트 캐싱


    private void Awake()
    {
        iconImage = GetComponent<Image>();
        line = GetComponent<Line>();
        pos = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(skillNodeState == 1 && !isGet)
        {
            ChangeState();
        }
    }

    void ChangeState()
    {
        switch (skillNodeState)
        {
            case 0:
                break;
            case 1:
                iconImage.sprite = canSkill;
                break;
            case 2:
                iconImage.sprite = onSkill;
                for(int i =0; i < nextIcons.Count<Attack>(); i++)
                {
                    Attack nextIconAttack = nextIcons[i];
                    if (nextIconAttack.skillNodeState == 0)
                    {
                        nextIconAttack.skillNodeState = 1;
                    }
                }
                break;

        }
    }



    public override void IconClick()  //아이콘을 클릭했을 때 (StatIcon을 참조)
    {

        if (skillPoint.SP >= needSP && SkillNodeState == 1 && !isGet && line.isFill) // 상태가 1이고 아직 획득하지 않은 상태이면
        {
            Debug.Log("성공");
            base.IconClick();
            skillPoint.SP -= needSP;
            SkillNodeState = 2;
            isGet = true;
            //TTT.instance.childRectTransform = pos;
        }
        else if(skillPoint.SP < needSP)
        {
            Debug.Log("스킬 포인트 부족");
        }
        else
        {
            Debug.Log("불가능");
        }

    }

    public int SkillNodeState  //스킬 상태가 바뀔때만 호출
    {
        get { return skillNodeState; }
        set
        {
            if (skillNodeState != value)
            {
                skillNodeState = value;
                ChangeState();
            }
        }
    }

    #region 마우스이벤트
    public void OnPointerEnter(PointerEventData eventData)  //마우스가 아이콘에 닿았을 때
    {
        iconDes.gameObject.SetActive(true);
        iconNameText.text = statName;
    }

    public void OnPointerExit(PointerEventData eventData)  //마우스가 아이콘에서 나왔을 때
    {
        iconDes.gameObject.SetActive(false);
        iconNameText.text = "";
    }
    #endregion
}
