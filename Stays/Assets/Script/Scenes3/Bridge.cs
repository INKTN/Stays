using System.Collections;
using UnityEngine;

/// <summary>
/// 20220606 ������
/// </summary>
public class Bridge : MonoBehaviour
{
    #region ���
    [Header("�t��")]
    public float speed = 1;
    private float objectiveSpeed = 2;
    [Header("�� �f��")]
    public bool skillUse = false;
    private string target = "�D��";
    private PlayerCharacter player;
    [Header("�ޯ�t��")]
    private UIManager skillUI;
    [Header("�i�_�ϥΧޯ�")]
    public bool canSkill;
    [Header("�����ǰe")]
    public Vector3 finPin;

    #endregion
    private void Start()
    {
        //print(gameObject.transform.GetChild(2).gameObject.name);//�T�{����W��
        skillUI = GameObject.Find("System").GetComponent<UIManager>();//���qUI������o�}��
        player = GameObject.Find(target).GetComponent<PlayerCharacter>();
    }

    private void Update()
    {
        if (speed == objectiveSpeed&&!skillUse) BuildBrodge();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == target)//�Y�i�J�d�򤺪�����O�D��
        {
            canSkill = true;//�i�ϥΧޯ�}��
        }
    }

    #region ��k
    public void SkillUse(float get)//��o�ޯ���s���ƭ�
    {
        speed += get;
    }
    private void BuildBrodge()//update�Y�t�׻P�ؼгt�׬ۦP�h���ìݪO�A��ܾ���
    {
        StartCoroutine(ChangePtion());
    }
    public void Skill()
    {
        if (canSkill&&!skillUse)//�p�G�i�ϥΧޯ�åB�ޯ�UI������
        {
        skillUI.SkillOn(transform);//�}��SKILLUI
        }
    }
    private IEnumerator ChangePtion()//��{��ܼҫ���1��
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        skillUse = true;
        yield return new WaitForSeconds(0.5f);
        player.Location(finPin);
    }
        #endregion
}
