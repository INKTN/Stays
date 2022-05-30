using UnityEngine;
/// <summary>
/// ��v���Ҧ�����3V
/// </summary>

public class Cameratest : MonoBehaviour
{
    #region ���
    [Header("�ؼЪ�")]
    public Transform target;
    [Header("Ĳ�N��m")]
    private Vector3 oneTPosition;
    [Header("�P�ؼжZ��"), Range(0, 50)]
    public float dis = 20f;
    [Header("�F�ӫ�"), Range(0, 50)]
    public float speed = 15;
    #endregion

    private void Start()
    {
        target = GameObject.Find("�D��").transform;//���D���ø��H�L
        transform.localPosition = Vector3.MoveTowards(transform.position, target.position, -dis);
        // cameraPosition = transform.position;
    }
    private void Update()
    {
        LS();
    }
    #region ��k
    private void LS()//Long Shot
    {
        if (Input.touchCount == 1)//�p�GĲ�N�I>1
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                oneTPosition = Input.touches[0].position;//�x�sĲ�N�I��m
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
               // transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * -1, 0, 0));//��v����m����(�u����X)
                transform.Translate(new Vector3(-Input.touches[0].deltaPosition.x * Time.deltaTime, -Input.touches[0].deltaPosition.y * Time.deltaTime, 0));

            }
        }
    }

    #endregion
}
