using UnityEngine;
using System.Collections;
/// <summary>
/// NPC²¾°Ê
/// </summary>

public class S1_ManipulationNPC : MonoBehaviour
{
    #region Äæ¦ì
    public float speed = 1f;
    public Rigidbody rb;
    public bool run;
    public Camera camera_NPC;
    #endregion
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (run) NPCGo();
    }
    private void NPCGo()
    {
        //rb.MovePosition(transform.position+new Vector3(7,0,8) * speed * Time.deltaTime);
        //yield return new WaitForSeconds(1);
        camera_NPC.transform.LookAt(transform);
        rb.MovePosition(transform.position + new Vector3(29, 0, 0) * speed * Time.deltaTime);
        if (transform.position.x > -24)
        {
            speed = 10;
            rb.MovePosition(transform.position + new Vector3(40, 0, 0) * speed * Time.deltaTime);
        }
    }
}
