using UnityEngine;
/// <summary>
/// 地面物品判定20220429
/// </summary>


public class GroundJudgment : MonoBehaviour
{

    #region 欄位
    public Transform touchObject;
    [Header("主角")]
    public Transform rem;
    #endregion
    public void OnGround(Transform selection)
    {
        touchObject = selection;
        PlayerCharacter player = GameObject.Find("主角").GetComponent<PlayerCharacter>();
        if (touchObject.GetComponent<area>().haveObstacle)
        {
            print("無法通過");
        }
        else
        {
            player.Move(selection);//呼叫主角移動
        }
    }
}
