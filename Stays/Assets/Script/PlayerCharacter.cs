using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// �D��player����
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    #region ���

    [Header("�ʵe����")]
    private Animator an;
    [Header("�����d��")]
    private Vector3 detectionRange = new Vector3(0, 0, 0);
    [Range(0, 50)]
    public float detectionSize;
    [Header("������m�վ�")]
    public Vector3 startPos;
    [Header("���ʳt��"), Range(0, 50)]
    public float speed;
    private NavMeshAgent agent;
    [Header("�樫��")]
    public bool walking;
    [Header("�ثe��m")]
    public string pt;
    #endregion
    private void Start()
    {
        #region ���o��������
       
        an = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();//���oAI�P�w
        speed = agent.speed;
        #endregion
        SetStartPosition();

    }
    private void OnDrawGizmos()
    {

        Gizmos.color = new Color(1, 0, 0, .5f);//�P�_�ϳ]�m���Ŧ�
        Gizmos.DrawSphere(transform.position + detectionRange, detectionSize);//�����Ϧ�m

    }//��m�������
    private void Update()
    {
        //print(Mathf.Ceil(agent.remainingDistance));���ռƭ�
        if (Mathf.Ceil(agent.remainingDistance) == 0)
        {
            an.SetBool("walk", false);
            agent.ResetPath();
        }//���m==0�A�����ʵe
        walking = an.GetBool("walk");
        //print(agent.hasPath);
        
    }
    #region ��k
    private void SetStartPosition()
    {
        Collider hit = Physics.OverlapSphere(transform.position + detectionRange, detectionSize)[0];
        pt = hit.name;
        transform.position = hit.transform.position + startPos;
    }//�}�l���B���D����m
    public void Move(Transform selection)
    {
        agent.speed = speed;
        SetStartPosition(); //�C��Ĳ�����ե��@��
        transform.LookAt(selection.position + startPos);//�ݦV�ؼ�
        an.SetBool("walk", true);
        agent.SetDestination(selection.position + startPos);//�ϥ�AI�޾ɦܦ�m

    }
    public void Location(Vector3 vector)
    {
        agent.isStopped = true;
        agent.ResetPath();
        transform.position = vector;
        //transform.LookAt(vector);//�ݦV�ؼ�
       
        //agent.SetDestination(vector);//�ϥ�AI�޾ɦܦ�m
        //SetStartPosition();
    }
    #endregion
}