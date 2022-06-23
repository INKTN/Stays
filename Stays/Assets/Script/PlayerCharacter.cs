using System.Collections;
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
        if (!an.GetBool("walk"))//�樫�ʵe�S���}�Ҥ~�����
        {
            target = selection.position + startPos;
            SetStartPosition(); //�C��Ĳ�����ե��@��
            StartCoroutine(TypeEffect());//20220623�ϥ�IEnumerator�Ϩ���|�b�C�Ӯ�l���y
                                         //agent.SetDestination(new Vector3(transform.position.x + unit, target.y, target.z));//�ϥ�AI�޾ɦܦ�m
        }
    }
    private IEnumerator TypeEffect()
    {
        var gap = target - transform.position;//��X����P�ؼжZ��
        //print(gap);�d�ݶZ���y��

        ///*X����(���k)///
        if (gap.x > 0)//�Y�Z���j��0=���k��
        {
            for(int i= (int)(Mathf.Abs(gap.x) / unit); i >0; i--)//�j��(i���Z��/���;�Yi��>0�h�������;�B�C������i��)
            {
                SetStartPosition(); //�C��Ĳ�����ե��@��
                an.SetBool("walk", true);//�}�Ұʵe
                Vector3 distance = new Vector3(transform.position.x+unit , transform.position.y, transform.position.z);
                transform.LookAt(distance);//�ݦV�ؼ�
                agent.SetDestination(distance);//��NAV��AI���ʦ��I
                //print("�V�k" + i + "��");
                yield return new WaitForSeconds(stop);//���y�]�w���
            }
        }
        else
        {
            for (int i = (int)(gap.x/ unit); i < 0; i++)
            {
                SetStartPosition(); //�C��Ĳ�����ե��@��
                an.SetBool("walk", true);
                Vector3 distance = new Vector3(transform.position.x - unit, transform.position.y, transform.position.z);
                transform.LookAt(distance);
                agent.SetDestination(distance);
                //print("�V��" + i + "��");
                yield return new WaitForSeconds(stop);
            }
        }
        ///*Z����(�e��)///
        if (gap.z > 0)
        {
            for (int i = (int)Mathf.Ceil(Mathf.Abs(gap.z) / unit); i != 0; i--)
            {
                SetStartPosition(); //�C��Ĳ�����ե��@��
                an.SetBool("walk", true);
                Vector3 distance = new Vector3(transform.position.x , transform.position.y, transform.position.z + unit);
                transform.LookAt(distance);//�ݦV�ؼ�
                agent.SetDestination(distance);
                //print("�V�e" + i + "��");
                yield return new WaitForSeconds(stop);
            }
        }
        else
        {
            //print((gap.z / unit));
            for (int i = (int)Mathf.Floor(gap.z / unit); i != 0; i++)
            {
                SetStartPosition(); //�C��Ĳ�����ե��@��
                an.SetBool("walk", true);
                Vector3 distance = new Vector3(transform.position.x , transform.position.y, transform.position.z - unit);
                transform.LookAt(distance);//�ݦV�ؼ�
                agent.SetDestination(distance);
                //print("�V��" + i + "��");
                yield return new WaitForSeconds(stop);
            }
        }
    }

    #endregion
}
