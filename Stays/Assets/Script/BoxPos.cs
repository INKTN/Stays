using UnityEngine;

public class BoxPos : MonoBehaviour
{
    #region ���
    [Header("�ؼЪ�")]
    public Transform target;
    [Header("������ʳt��")]
    public float speed=6.5F;
    #endregion
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
    }
}
