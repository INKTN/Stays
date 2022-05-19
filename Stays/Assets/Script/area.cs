using UnityEngine;
using System;////Array.IndexOf使用
/// <summary>
/// 區域內是否有生物20220501
/// </summary>
public class area : MonoBehaviour
{
    #region 欄位
    [Header("障礙物判定")]
    public bool haveObstacle;
    [Header("偵測範圍")]
    public Vector3 detectionRange=Vector3.one;
    public Vector3 detectionHight;
    [Header("觸碰範圍顯示")]
    public bool gizmosOn;
    [Header("無法通行障礙物TAG")]
    public string[] draggingTag;

    #endregion
   
    private void OnDrawGizmos()
    {
        if (gizmosOn)
        {
            Gizmos.color = new Color(0, 0, 1, .2f);//判斷區設置為藍色
            Gizmos.DrawCube(transform.position + detectionHight, detectionRange);//偵測區位置
        }
    }

    private void Update()
    {
       
        CheckArea();
    }
    #region 方法
    public void CheckArea()//檢測內部是否有東西
    {
        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange/2, Quaternion.identity);//(中心點，大小，旋轉，圖層碼)
        haveObstacle = false;
        int i = 0;
        while (i < hit.Length)//若i小於hit最大值
        {
            print(transform.name+"Hit : " + hit[i].name+ hit[i].tag + ",第"+ i+"物件,T判定"+ Array.IndexOf(draggingTag, hit[i]));
            if (Array.IndexOf(draggingTag, hit[i].tag) > -1) haveObstacle = true;//有障礙物開啟
            else haveObstacle = false;
            i++;
        }
    }
    #endregion
}
