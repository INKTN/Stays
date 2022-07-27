using UnityEngine;

/// <summary>
/// �۰ʲ��ͪ���
/// </summary>
public class Spawner : MonoBehaviour
{
    #region ���
    public float maxtime = 3f;
    public float timer = 0f;
    //public GameObject table;

    [Header("�ͦ�����")]
    public GameObject[] box;
    public float[] row ;
    //Guest guest;
    #endregion

    private void Start()
    {
        //table = GameObject.Find("�a�i");
        GameObject newbox = Instantiate(box[Random.Range(0, 6)]);
        newbox.transform.position = new Vector3(15f, row[Random.Range(0, 3)], 0);
    }
    private void FixedUpdate()
    {
        if (timer > maxtime)
        {
            GameObject newbox = Instantiate(box[Random.Range(0, 3)]);
            newbox.transform.position = new Vector3(15f, row[Random.Range(0, 3)], 0);
           // guest = newbox.GetComponent<Guest>();
            //guest.Go(table.transform.position, 20f);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
   
}
