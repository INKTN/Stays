using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 攝影機模式切換3V
/// </summary>

public class Cameratest : MonoBehaviour
{
    #region 欄位
    [Header("目標物")]
    public Transform target;
    //上次紀錄對象
    private GameObject lastObj;
    public Vector3 rayLine;

    [Header("觸摸位置")]
    private Vector3 oneTPosition;
    [Header("邊界範圍")]
    public float x_borderMax;
    public float x_borderMin;
    public float y_borderMax;
    public float y_borderMin;
    public float z_borderMax;
    public float z_borderMin;
    [Header("與目標距離"), Range(0, 50)]
    public float dis = 20f;
    [Header("靈敏度"), Range(0, 50)]
    public float speed = 15;
    private DialongueSystem dialongue;//對話框偕同程序
    [Header("鏡頭切換開關")]
    public bool caTask=true;
    [Header("觸控開關")]
    public bool switches;
    #endregion

    private void Start()
    {
        target = GameObject.Find("主角").transform;//找到主角並跟隨他
        transform.localPosition = Vector3.MoveTowards(transform.position, target.position, -dis);
        dialongue = GameObject.Find("System").GetComponent<DialongueSystem>();//找到對話框偕同程序
        // cameraPosition = transform.position;
        
    }
    private void Update()
    {
        if (!dialongue.display&&!switches)//若是對話框顯示則不觸控
        {
            LS();
            Border();
        }
        Masking();
       
    }
   
    #region 方法
    private void LS()//Long Shot
    {
        if (Input.touchCount == 1)//如果觸摸點>1
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                oneTPosition = Input.touches[0].position;//儲存觸摸點位置
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
               // transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * -1, 0, 0));//攝影機位置平移(只移動X)
                transform.Translate(new Vector3(-Input.touches[0].deltaPosition.x * Time.deltaTime, -Input.touches[0].deltaPosition.y * Time.deltaTime, 0));
            }
        }
    }
    private void Border()//攝影機邊界
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, x_borderMin, x_borderMax),
            Mathf.Clamp(transform.position.y, y_borderMin, y_borderMax),
            Mathf.Clamp(transform.position.z, z_borderMin, z_borderMax));
    }
    private void Masking()//遮擋透明
    {
        Debug.DrawLine(target.transform.position + rayLine, transform.position, Color.red);//畫線
        RaycastHit hit;

        if (Physics.Linecast(target.transform.position + rayLine, transform.position, out hit))
        {
            if (lastObj != null)
            {
                Renderer renderer = lastObj.GetComponent<Renderer>();
                Color _color = renderer.material.color;
                _color.a = 1f;
                renderer.material.SetColor("_Color", _color);
                lastObj = null;

            }
            lastObj = hit.collider.gameObject;
            string nameTag = lastObj.tag;
            //判斷
            if (nameTag != "MainCamera" && nameTag != "terrain")
            {
                //使遮擋物變透明
                Renderer renderer = lastObj.GetComponent<Renderer>();
                Color _color = renderer.material.color;
                _color.a = 0.5f;
                renderer.material.SetColor("_Color", _color);
            }
        }//還原
        else if (lastObj != null)
        {
                Renderer renderer = lastObj.GetComponent<Renderer>();
            Color _color = renderer.material.color;
            _color.a = 1f;
            renderer.material.SetColor("_Color", _color);
            lastObj = null;
            
        }
    }

    #endregion
}
