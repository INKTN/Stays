using UnityEngine;
/// <summary>
/// 20220606 ������
/// </summary>
public class Bridge : MonoBehaviour
{
    #region ���
    [Header("�t��")]
    public float speed = 1;
    private float objectiveSpeed = 2;
    [Header("�� �f��")]
    public bool skillUse=false;
    #endregion
    private void Start()
    {
        //print(gameObject.transform.GetChild(2).gameObject.name);//�T�{����W��
    }
    private void Update()
    {
        if (speed == objectiveSpeed) BuildBrodge();
    }
    #region ��k
    public void SkillUse(float get)//��o�ޯ���s���ƭ�
    {
        speed += get;
    }
    private void BuildBrodge()//update�Y�t�׻P�ؼгt�׬ۦP�h���ìݪO�A��ܾ���
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);

    }
    #endregion
}
