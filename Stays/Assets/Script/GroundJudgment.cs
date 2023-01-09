using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 地面物品判定20220429
/// 20230109關卡一進入車站判斷
/// </summary>


public class GroundJudgment : MonoBehaviour
{

    #region 欄位
    public Transform touchObject;
    [Header("主角")]
    public Transform rem;
    [Header("當前場景名稱")]
    public string scene;
    [Header("需求物件")]
    public GameObject target;
    private void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }
    #endregion
    public void OnGround(Transform selection)
    {
        touchObject = selection;
        PlayerCharacter player = GameObject.Find("主角").GetComponent<PlayerCharacter>();
        if (touchObject.GetComponent<area>().haveObstacle)
        {
            print("無法通過");
        }
        else if (scene== "關卡1 城市")
        {
            var cityTask= GameObject.Find("System").GetComponent<CityTask>();
            var s1_Tower= GameObject.Find("鐘塔").GetComponent<S1_Tower>();
            if (cityTask.b_towerDialogue && cityTask.c_trust && !cityTask.trainStation)
            {
                //print("進入條件"+selection.transform+target.transform);
                if (selection.transform == target.transform)
                {
                    player.Move(selection);//呼叫主角移動
                }
                else
                {
                    s1_Tower.GJDialong();
                }
            }
            else if(cityTask.b_towerDialogue && cityTask.c_trust && cityTask.trainStation)
            {
                if (selection.transform == target.transform)
                {
                    s1_Tower.GJDialong();
                }
                else
                {
                   
                    player.Move(selection);//呼叫主角移動
                }
            }
            else
            {
                player.Move(selection);//呼叫主角移動
            }
        }
        else
        {
            player.Move(selection);//呼叫主角移動
        }
    }
}
