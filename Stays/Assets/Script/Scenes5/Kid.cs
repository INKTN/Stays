using UnityEngine;

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
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
       if (other.name == target) dialongueSystem.StartDialogue(dataDalogues.conversationContent);//��ܸ��Ū��
    }
    
}
