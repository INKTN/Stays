using UnityEngine.SceneManagement;
using UnityEngine;

public class TaskScenes : MonoBehaviour
{
    [Header("攝影機")]
    public Camera setCamera;
    [Header("切換場景名稱")]
    public string scenes;

    private float begainTime = 0f;//最初點擊時間
    private Vector2 startPos = Vector2.zero;//觸碰起始點

    public float quickDoubleTabInterval = 0.15f;
    public float lastTouchTime;//上一次點擊放開的時間
    public string target;
    private static float intervals;//間隔時間
    private static Touch lastTouch;//目前沒用到，不果主要是記錄上一次的觸碰
    private void Start()
    {
        setCamera = GameObject.Find("TreeCa").GetComponent<Camera>();

    }
    void FixedUpdate()
    {
        TouchTree();
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
                
                    RaycastHit chHit;
                    Ray chRay = setCamera.ScreenPointToRay(pos);
                    Physics.Raycast(chRay, out chHit);
                    print(chHit.transform.parent.gameObject.name);
                    // if (Physics.Raycast(ray, out hit) && hit.transform.parent.gameObject.name == target)
                    startPos = touch.position;
                    begainTime = Time.realtimeSinceStartup;
                    if (Time.realtimeSinceStartup - lastTouchTime < quickDoubleTabInterval)
                    {
                        SceneManager.LoadScene(scenes);
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
