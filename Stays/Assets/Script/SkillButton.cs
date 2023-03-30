using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    public Scene scene;
    #endregion
    private void Awake()
    {
        //����ɨ��oUI����P��ܪ���
        skillOpen = GameObject.Find("System").GetComponent<UIManager>();
        scene = SceneManager.GetActiveScene();
        Target = skillOpen.touchObject;
        //print(Target);
        //print(scene.name);
    }
    
    public void SkillFast()
    {
        #region ���d�@
        if (scene.name == "���d1 ����" && Target == null || Target.name == "�M���")
        {
            var cleaning = GameObject.Find("�M���").GetComponent<S1_CleaningStaff>();
            cleaning.SkillUse(speed);
        }
        #endregion
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
        if(scene.name=="���d3 �k�~" && Target == null||Target.name=="Kid")
        {
            var kid= GameObject.Find("Kid").GetComponent<Kid>();
            kid.SkillUse(speed);
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
