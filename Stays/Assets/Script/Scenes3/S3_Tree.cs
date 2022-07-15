using UnityEngine;
using UnityEngine.SceneManagement;
public class S3_Tree : MonoBehaviour
{
    #region 欄位
    [Header("攝影機")]
    public Camera setCamera;
    public Camera oriCamera;
    public bool ch;
    private Cameratest cameratest;
    private Kid kid;

    private float begainTime = 0f;//最初點擊時間
    private Vector2 startPos = Vector2.zero;//觸碰起始點

    public float quickDoubleTabInterval = 0.15f;
    public float lastTouchTime;//上一次點擊放開的時間
    public string debugInfo = "Nothing";
    public string target;
    private static float intervals;//間隔時間
    private static Touch lastTouch;//目前沒用到，不果主要是記錄上一次的觸碰
    #endregion

    private void Start()
    {
        oriCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        setCamera = GameObject.Find("TreeCa").GetComponent<Camera>();
        cameratest = GameObject.Find("MainCamera").GetComponent<Cameratest>();
        kid= GameObject.Find("Kid").GetComponent<Kid>();
    }
    void FixedUpdate()
    {
        if(kid.dalogues1Fin)TouchTree();
        //print(Input.touchCount);
        //print(Camera.main);
    }
    private void TouchTree()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;
            //若是觸碰開始
            if (touch.phase == TouchPhase.Began)
            {
                if (ch)
                {
                    RaycastHit chHit;
                    Ray chRay = setCamera.ScreenPointToRay(pos);
                    Physics.Raycast(chRay, out chHit);
                    print(chHit.transform.parent.gameObject.name);
                    // if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target)
                    startPos = touch.position;
                    begainTime = Time.realtimeSinceStartup;
                    if (Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
                    {
                        print("if測");
                        debugInfo = "touchCount";
                        ch = !ch;
                        setCamera.enabled = ch;
                        oriCamera.enabled = !ch;
                        cameratest.caTask = true;
                    }
                }
                else
                {
                    RaycastHit hit;
                    Ray ray = oriCamera.ScreenPointToRay(pos);
                    Physics.Raycast(ray, out hit);
                    print(hit.transform.parent.gameObject.name);
                    // if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target)
                    startPos = touch.position;
                    begainTime = Time.realtimeSinceStartup;
                    if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target && Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
                    {
                        //print("if測");
                        debugInfo = "touchCount";
                        SceneManager.LoadScene(4);
                    }
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                intervals = Time.realtimeSinceStartup - begainTime;
                lastTouchTime = Time.realtimeSinceStartup;
                lastTouch = touch;
            }
        }
    }

}