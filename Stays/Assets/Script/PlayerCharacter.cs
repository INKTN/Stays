using System.Collections;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 主角player控制
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    #region 欄位
    [Header("剛體")]
    private Rigidbody rb;
    [Header("動畫控制")]
    private Animator an;
    [Header("偵測範圍")]
    private Vector3 detectionRange = new Vector3(0, 0, 0);
    [Range(0,50)]
    public float detectionSize;
    [Header("偵測位置調整")]
    public Vector3 startPos;
    [Header("移動速度"), Range(0, 50)]
    public float speed;
    [Header("停止時間"),Range(0,50)]
    public float stop;
    private NavMeshAgent agent;
    [Header("目標位置")]
    private Vector3 target;
    [Header("一格距離")]
    public float unit=10;
    #endregion
    private void Start()
    {
        #region 取得相關元件
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();//取得AI判定
        #endregion
        SetStartPosition();

    }
    private void OnDrawGizmos()
    {
       
            Gizmos.color = new Color(1, 0, 0, .5f);//判斷區設置為藍色
            Gizmos.DrawSphere(transform.position+detectionRange,detectionSize);//偵測區位置
        
    }//位置偵測顯示
    private void Update()
    {
       //print(Mathf.Ceil(agent.remainingDistance));測試數值
        if (Mathf.Ceil(agent.remainingDistance) == 0) an.SetBool("walk", false);//當位置==0，關閉動畫
    }
    #region 方法
    private void SetStartPosition()
    {
        Collider hit = Physics.OverlapSphere(transform.position + detectionRange, detectionSize)[0];
       //print(hit.name);
        transform.position = hit.transform.position+startPos;
    }//開始時矯正主角位置
    public void Move(Transform selection)
    {
        target = selection.position+startPos;
        SetStartPosition(); //每次觸控都校正一次
        transform.LookAt(target);//看向目標
        an.SetBool("walk",true);


        StartCoroutine(TypeEffect());
        //agent.SetDestination(new Vector3(transform.position.x + unit, target.y, target.z));//使用AI引導至位置
        
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
