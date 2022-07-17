using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// �ޯ���s
/// 20220418 �ܴ��t��(�אּ�W�[���)
/// </summary>

public class SkillButton : MonoBehaviour
{
    #region ���
    
    [Header("�t�׭�"), Range(-20, 20)]
    public float speed;
    //UI������}��
    private UIManager skillOpen;
    //Ĳ�I����
    public Transform Target;
  
    #endregion
    private void Awake()
    {
        //����ɨ��oUI����P��ܪ���
        skillOpen = GameObject.Find("System").GetComponent<UIManager>();
        Target = skillOpen.touchObject;
       
    }
    
    public void SkillFast()
    {
        #region ���d�T
        if (Target.tag== "Bridge")//���d�T_��
        {
           var bridge = Target.GetComponent<Bridge>();//�p�G�I�쪺�F��TAG���ʪ��A���o�ʪ��}��
            bridge.SkillUse(speed);//�I�s�ʪ����ܳt�ת���k
        }
        if (Target.name == "�ޯ�ξ�")//���d�T_Tree
        {
            var tree = Target.GetComponent<S3_Tree>();
            tree.SkillUse(speed);
        }
        #endregion
        if (Target.tag == "obstacle")//2022043
        {
           var get = Target.GetComponent<TreeVariation>();//�p�G�I�쪺�F��TAG����A���o�ʪ��}��
            get.SkillUse(speed);//�I�s����ܳt�ת���k
        }
        //print("�ϥΧޯ�" + speed);
        skillOpen.skillOpen = false;//����UI�����ܶ}��
        Destroy(GameObject.Find("skill UI(Clone)"));//�R��SkillUI
    }
}
