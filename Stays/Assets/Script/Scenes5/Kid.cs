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
    public DataDalogue[] dataDalogues;
    private bool dalogues1Fin;
    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;
    [Header("Ĳ�o��H")]
    public string target = "�D��";
    [Header("�����d��")]
    public Vector3 detectionRange = Vector3.one;
    public Vector3 detectionHight;
    [Header("Ĳ�I�d�����")]
    public bool gizmosOn;

    #endregion
    private void Start()
    {
        an = GetComponent<Animator>();
    }
    private void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        if (gizmosOn)
        {
            Gizmos.color = new Color(1, 0, 0, .5f);//�P�_�ϳ]�m���Ŧ�
            Gizmos.DrawCube(transform.position + detectionHight, detectionRange);//�����Ϧ�m
        }
    }//��m�������
  
    #region ��k
    public void Check()//�˴������O�_���F��éI�s���
    {
        ///print("�����^��");
        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange / 2, Quaternion.identity);//(�����I�A�j�p�A����A�ϼh�X)
        int i = 0;
        transform.LookAt(GameObject.Find("�D��").transform);
        while (i < hit.Length)//�Yi�p��hit�̤j��
        {
            print(hit[i].name);
            //Contains:�b�r�ꤤ�M��A�Y���^��True
            #region ���
            if (hit[i].name.Contains(target)) 
            {
                if (!dalogues1Fin)
                {
                    dialongueSystem.StartDialogue(dataDalogues[0].conversationContent);//��ܸ��Ū��
                    dialongueSystem.NameEnter(dataDalogues[0].talkName);
                    dalogues1Fin = true;
                }
                else
                {
                    dialongueSystem.StartDialogue(dataDalogues[1].conversationContent);//��ܸ��Ū��
                    dialongueSystem.NameEnter(dataDalogues[1].talkName);
                }
            }
            #endregion
            i++;
        }
    }
    public void Control()
    {
        if (dalogues1Fin) 
        {

        }
    }
    #endregion
}
