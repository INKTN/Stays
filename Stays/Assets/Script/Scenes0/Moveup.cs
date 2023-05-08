using UnityEngine;
/// <summary>
/// 圖移動
/// </summary>
public class Moveup : MonoBehaviour
{
   public float moveDistance = 100.0f; // 移动的距离
    public float moveTime = 1.0f; // 移动的时间

    void Start()
    {
    }
   public void Move()
    {
        // 计算起始和结束位置
        Vector2 startPos = GetComponent<RectTransform>().anchoredPosition;
        Vector2 endPos = new Vector2(startPos.x, startPos.y + moveDistance);

        // 执行移动
        LeanTween.move(GetComponent<RectTransform>(), endPos, moveTime);

    }
}
