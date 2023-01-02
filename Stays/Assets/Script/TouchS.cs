using UnityEngine;
using System;////Array.IndexOf使用
/// <summary>
/// 觸碰判定系統
/// 20220415 可運作、但還沒完善 詳情https://www.youtube.com/watch?v=QDldZWvNK_E
/// 選擇明顯顯示 搭配C#為:hightlightSelectionResponse、ISelectionResponse
/// 20220416跳出UI 搭配C#為UIManager 
/// 20220429地面選擇
/// </summary>

public class TouchS : MonoBehaviour
{
    #region 欄位
    [Header("能叫出技能使用物件TAG")]
    public string[] draggingTag;
    [Header("攝影機")]
    public Camera cam;
    [Header("選擇_材質替換")]
    public Material hightmaterial;
    [Header("原有材質")]
    public Material orimaterial;
    private hightlightSelectionResponse _selectionResponse;
    public Transform _salaction;
    //UI召喚
    
    private UIManager skillUI;
    private GroundJudgment ground;
    private DialongueSystem dialongue;//對話框偕同程序
    private Cameratest cameratest;

    [Header("主角")]//20220620讓角色只能走一格
    private PlayerCharacter character;
    [Range(-50, 50), Header("格子距離")]
    public float distance;
    [Header("觸控開關")]
    public bool switches;
    #endregion
    private void Start()
    {
        skillUI = GameObject.Find("System").GetComponent<UIManager>();//先從UI控制中取得腳本
        ground= GameObject.Find("System").GetComponent<GroundJudgment>();
        dialongue = GameObject.Find("System").GetComponent<DialongueSystem>();//找到對話框偕同程序
        character = GameObject.Find("主角").GetComponent<PlayerCharacter>();
        cameratest = GameObject.Find("MainCamera").GetComponent<Cameratest>();
    }

    void FixedUpdate()
    {
        #region 材質還原
        if (_salaction != null)
        {
            var selectionRenderer = _salaction.GetComponent<Renderer>();
            if (selectionRenderer !=null)
            {
                selectionRenderer.material = orimaterial;
            }

        }
        #endregion
        if (!dialongue.display&&!character.walking&&cameratest.caTask&&!switches) //若是對話框顯示則不觸控
            RayTouch();//觸碰
        #region 觸碰物材質轉換
        if (_salaction != null)
        {
            var selectionRenderer = _salaction.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = hightmaterial;
            }

        }
        #endregion
    }
    private void RayTouch()//觸碰
    {
        //若是觸控點=1
        if (Input.touchCount == 1)
        {
            //紀錄觸控訊息
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;
            //若是觸碰開始
            if (touch.phase == TouchPhase.Began)
            {
                //觸碰位置攝影機發出RAY
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(pos);
                _salaction = null;
                //print(Array.IndexOf(draggingTag, hit.collider.tag));//檢驗觸碰用20220423


                #region 地板
                if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ground" && !skillUI.skillOpen)//技能UI不是開的才能換地板
                {

                    var selection = hit.transform;
                    //print(selection.name+selection.position);
                    orimaterial = selection.GetComponent<Renderer>().material;
                    ground.OnGround(selection);
                    _salaction = selection;

                }
                #endregion
                #region NPC
                if (Physics.Raycast(ray, out hit) && hit.collider.tag == "NPC" && !skillUI.skillOpen)
                {
                    var selection = hit.transform;
                    //print(selection.name + selection.position);
                    orimaterial = selection.GetComponent<Renderer>().material;
                    #region NPC
                    //要在NPC處寫判斷格子
                    if (selection.name == "Kid")
                    {
                        //print(selection.name == "Kid");
                        Kid getHit = selection.GetComponent<Kid>();
                        getHit.Check();
                    }
                    #endregion
                    //呼叫攝影機切換視角
                    _salaction = selection;
                }
                #endregion
            }

        }
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            _salaction = null;
            #region 地板
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ground" && !skillUI.skillOpen)//技能UI不是開的才能換地板
            {

                var selection = hit.transform;
                //print(selection.name+selection.position);
                orimaterial = selection.GetComponent<Renderer>().material;
                ground.OnGround(selection);
                _salaction = selection;

            }
            #endregion
            #region NPC
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "NPC" && !skillUI.skillOpen)
            {
                var selection = hit.transform;
                //print(selection.name + selection.position);
                orimaterial = selection.GetComponent<Renderer>().material;
                #region NPC
                //要在NPC處寫判斷格子
                if (selection.name == "Kid")
                {
                    //print(selection.name == "Kid");
                    Kid getHit = selection.GetComponent<Kid>();
                    getHit.Check();
                }
                #endregion
                //呼叫攝影機切換視角
                _salaction = selection;
            }
        }
        #endregion
    }
}