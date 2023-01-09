using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// �a�����~�P�w20220429
/// 20230109���d�@�i�J�����P�_
/// </summary>


public class GroundJudgment : MonoBehaviour
{

    #region ���
    public Transform touchObject;
    [Header("�D��")]
    public Transform rem;
    [Header("��e�����W��")]
    public string scene;
    [Header("�ݨD����")]
    public GameObject target;
    private void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }
    #endregion
    public void OnGround(Transform selection)
    {
        touchObject = selection;
        PlayerCharacter player = GameObject.Find("�D��").GetComponent<PlayerCharacter>();
        if (touchObject.GetComponent<area>().haveObstacle)
        {
            print("�L�k�q�L");
        }
        else if (scene== "���d1 ����")
        {
            var cityTask= GameObject.Find("System").GetComponent<CityTask>();
            var s1_Tower= GameObject.Find("����").GetComponent<S1_Tower>();
            if (cityTask.b_towerDialogue && cityTask.c_trust && !cityTask.trainStation)
            {
                //print("�i�J����"+selection.transform+target.transform);
                if (selection.transform == target.transform)
                {
                    player.Move(selection);//�I�s�D������
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
                   
                    player.Move(selection);//�I�s�D������
                }
            }
            else
            {
                player.Move(selection);//�I�s�D������
            }
        }
        else
        {
            player.Move(selection);//�I�s�D������
        }
    }
}
