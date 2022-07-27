using UnityEngine;

/// <summary>
/// 自動產生物件
/// </summary>
public class Spawner : MonoBehaviour
{
    #region 欄位
    public float maxtime = 3f;
    public float timer = 0f;
    //public GameObject table;

    [Header("生成物件")]
    public GameObject[] box;
    public float[] row ;
    //Guest guest;
    #endregion

    private void Start()
    {
        //table = GameObject.Find("吧檯");
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
