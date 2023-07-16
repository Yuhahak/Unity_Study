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
    public int skillNodeState;  // ��ų���� 0 ��Ȱ��ȭ, 1 Ȱ��ȭ����, 2 Ȱ��ȭ
    public string statName;  // ���� �̸�
    [Multiline(3)]
    public string statDes;  //���� ����
    public int needSP;  // �ʿ��� ��ų����Ʈ
    [Space(10f)]
    public Sprite canSkill; // ��ų�� ���� �� ���� �� ���� �̹���
    public Sprite onSkill; // ��ų�� ������ �� ���� �̹���

    [Header("Info_Private")]
    public bool isGet = false; //��ų�� �������� ����
    private Image iconImage;  // ���� ������ �̹���
    private RectTransform pos;


    [Header("Next Icon")] // ���� ���� ������
    public Attack[] nextIcons;  // �����ܵ��� Attck ��ũ��Ʈ ĳ��


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



    public override void IconClick()  //�������� Ŭ������ �� (StatIcon�� ����)
    {

        if (skillPoint.SP >= needSP && SkillNodeState == 1 && !isGet && line.isFill) // ���°� 1�̰� ���� ȹ������ ���� �����̸�
        {
            Debug.Log("����");
            base.IconClick();
            skillPoint.SP -= needSP;
            SkillNodeState = 2;
            isGet = true;
            //TTT.instance.childRectTransform = pos;
        }
        else if(skillPoint.SP < needSP)
        {
            Debug.Log("��ų ����Ʈ ����");
        }
        else
        {
            Debug.Log("�Ұ���");
        }

    }

    public int SkillNodeState  //��ų ���°� �ٲ𶧸� ȣ��
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

    #region ���콺�̺�Ʈ
    public void OnPointerEnter(PointerEventData eventData)  //���콺�� �����ܿ� ����� ��
    {
        iconDes.gameObject.SetActive(true);
        iconNameText.text = statName;
    }

    public void OnPointerExit(PointerEventData eventData)  //���콺�� �����ܿ��� ������ ��
    {
        iconDes.gameObject.SetActive(false);
        iconNameText.text = "";
    }
    #endregion
}
