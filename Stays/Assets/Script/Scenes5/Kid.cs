using UnityEngine;
/// <summary>
/// �p��NPC�}��20220701
/// </summary>

public class Kid : MonoBehaviour
{
    #region ���
    [Header("�ʵe���")]
    private Animator an;
    [Header("��ܸ��")]
    public DataDalogue dataDalogues;
    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;
    [Header("Ĳ�o��H")]
    public string target = "�D��";
    [Header("�����d��")]
    public Vector3 detectionRange = Vector3.one;
    public Vector3 detectionHight;
    
    #endregion

    private void Start()
    {
        an = GetComponent<Animator>();
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = new Color(1, 0, 0, .5f);//�P�_�ϳ]�m���Ŧ�
        Gizmos.DrawCube(transform.position + detectionHight, detectionRange);//�����Ϧ�m

    }//��m�������
  
    #region ��k
    public void Check()//�˴������O�_���F��
    {
        print("�����^��");
        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange / 2, Quaternion.identity);//(�����I�A�j�p�A����A�ϼh�X)
        int i = 0;
        while (i < hit.Length)//�Yi�p��hit�̤j��
        {
            print(hit[i].name);
            //Contains:�b�r�ꤤ�M��A�Y���^��True
            if (hit[i].name.Contains(target)) 
            {
                dialongueSystem.StartDialogue(dataDalogues.conversationContent);//��ܸ��Ū��
                dialongueSystem.NameEnter(dataDalogues.talkName);
            }
            
            i++;
        }
    }
    #endregion
}
