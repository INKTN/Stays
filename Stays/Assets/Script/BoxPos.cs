using UnityEngine;

public class BoxPos : MonoBehaviour
{
    #region 欄位
    [Header("目標物")]
    public Transform target;
    [Header("方塊移動速度")]
    public float speed=6.5F;
    #endregion
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
    }
}
