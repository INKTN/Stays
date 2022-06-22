using System.Collections;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// �D��player����
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    #region ���
    [Header("����")]
    private Rigidbody rb;
    [Header("�ʵe����")]
    private Animator an;
    [Header("�����d��")]
    private Vector3 detectionRange = new Vector3(0, 0, 0);
    [Range(0,50)]
    public float detectionSize;
    [Header("������m�վ�")]
    public Vector3 startPos;
    [Header("���ʳt��"), Range(0, 50)]
    public float speed;
    [Header("����ɶ�"),Range(0,50)]
    public float stop;
    private NavMeshAgent agent;
    [Header("�ؼЦ�m")]
    private Vector3 target;
    [Header("�@��Z��")]
    public float unit=10;
    #endregion
    private void Start()
    {
        #region ���o��������
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();//���oAI�P�w
        #endregion
        SetStartPosition();

    }
    private void OnDrawGizmos()
    {
       
            Gizmos.color = new Color(1, 0, 0, .5f);//�P�_�ϳ]�m���Ŧ�
            Gizmos.DrawSphere(transform.position+detectionRange,detectionSize);//�����Ϧ�m
        
    }//��m�������
    private void Update()
    {
       //print(Mathf.Ceil(agent.remainingDistance));���ռƭ�
        if (Mathf.Ceil(agent.remainingDistance) == 0) an.SetBool("walk", false);//���m==0�A�����ʵe
    }
    #region ��k
    private void SetStartPosition()
    {
        Collider hit = Physics.OverlapSphere(transform.position + detectionRange, detectionSize)[0];
       //print(hit.name);
        transform.position = hit.transform.position+startPos;
    }//�}�l���B���D����m
    public void Move(Transform selection)
    {
        target = selection.position+startPos;
        SetStartPosition(); //�C��Ĳ�����ե��@��
        transform.LookAt(target);//�ݦV�ؼ�
        an.SetBool("walk",true);


        StartCoroutine(TypeEffect());
        //agent.SetDestination(new Vector3(transform.position.x + unit, target.y, target.z));//�ϥ�AI�޾ɦܦ�m
        
    }
    private IEnumerator TypeEffect()
    {
        var gap = target - transform.position;
        print(gap);
        if (gap.x > 0)
        {
            for(int i= (int)(Mathf.Abs(gap.x) / unit); i > 0; i--)
            {
                Vector3 distance = new Vector3(transform.position.x + gap.x, transform.position.y, transform.position.z);
                agent.SetDestination(distance);
                print(i);
                yield return new WaitForSeconds(stop);
            }
        }
        if (gap.x < 0)
        {
            for (int i = (int)(Mathf.Abs(gap.x) / unit); i < 0; i++)
            {
                Vector3 distance = new Vector3(transform.position.x+gap.x, transform.position.y, transform.position.z);
                agent.SetDestination(distance);
                print(i);
                yield return new WaitForSeconds(stop);
            }
        }

    }

    #endregion
}
