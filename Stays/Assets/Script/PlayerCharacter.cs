using System.Collections;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 主角player控制
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    #region 欄位
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
        if (!an.GetBool("walk"))//行走動畫沒有開啟才能執行
        {
            target = selection.position + startPos;
            SetStartPosition(); //每次觸控都校正一次
            StartCoroutine(TypeEffect());//20220623使用IEnumerator使角色會在每個格子停頓
                                         //agent.SetDestination(new Vector3(transform.position.x + unit, target.y, target.z));//使用AI引導至位置
        }
    }
    private IEnumerator TypeEffect()
    {
        var gap = target - transform.position;//算出角色與目標距離
        //print(gap);查看距離座標

        ///*X移動(左右)///
        if (gap.x > 0)//若距離大於0=往右走
        {
            for(int i= (int)(Mathf.Abs(gap.x) / unit); i >0; i--)//迴圈(i為距離/單位;若i還>0則持續執行;且每次遞減i值)
            {
                SetStartPosition(); //每次觸控都校正一次
                an.SetBool("walk", true);//開啟動畫
                Vector3 distance = new Vector3(transform.position.x+unit , transform.position.y, transform.position.z);
                transform.LookAt(distance);//看向目標
                agent.SetDestination(distance);//使NAV的AI移動至點
                //print("向右" + i + "格");
                yield return new WaitForSeconds(stop);//停頓設定秒數
            }
        }
        else
        {
            for (int i = (int)(gap.x/ unit); i < 0; i++)
            {
                SetStartPosition(); //每次觸控都校正一次
                an.SetBool("walk", true);
                Vector3 distance = new Vector3(transform.position.x - unit, transform.position.y, transform.position.z);
                transform.LookAt(distance);
                agent.SetDestination(distance);
                //print("向左" + i + "格");
                yield return new WaitForSeconds(stop);
            }
        }
        ///*Z移動(前後)///
        if (gap.z > 0)
        {
            for (int i = (int)Mathf.Ceil(Mathf.Abs(gap.z) / unit); i != 0; i--)
            {
                SetStartPosition(); //每次觸控都校正一次
                an.SetBool("walk", true);
                Vector3 distance = new Vector3(transform.position.x , transform.position.y, transform.position.z + unit);
                transform.LookAt(distance);//看向目標
                agent.SetDestination(distance);
                //print("向前" + i + "格");
                yield return new WaitForSeconds(stop);
            }
        }
        else
        {
            //print((gap.z / unit));
            for (int i = (int)Mathf.Floor(gap.z / unit); i != 0; i++)
            {
                SetStartPosition(); //每次觸控都校正一次
                an.SetBool("walk", true);
                Vector3 distance = new Vector3(transform.position.x , transform.position.y, transform.position.z - unit);
                transform.LookAt(distance);//看向目標
                agent.SetDestination(distance);
                //print("向後" + i + "格");
                yield return new WaitForSeconds(stop);
            }
        }
    }

    #endregion
}
