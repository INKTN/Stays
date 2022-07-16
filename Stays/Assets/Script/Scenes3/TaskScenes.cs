using UnityEngine.SceneManagement;
using UnityEngine;

public class TaskScenes : MonoBehaviour
{
    [Header("��v��")]
    public Camera setCamera;
    [Header("���������W��")]
    public string scenes;

    private float begainTime = 0f;//�̪��I���ɶ�
    private Vector2 startPos = Vector2.zero;//Ĳ�I�_�l�I

    public float quickDoubleTabInterval = 0.15f;
    public float lastTouchTime;//�W�@���I����}���ɶ�
    public string target;
    private static float intervals;//���j�ɶ�
    private static Touch lastTouch;//�ثe�S�Ψ�A���G�D�n�O�O���W�@����Ĳ�I
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
            //�Y�OĲ�I�}�l
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
