using UnityEngine;

public class TestLookAt : MonoBehaviour
{
    private void Update()
    {
        LookAt();
    }
    void LookAt()
    {
        transform.LookAt(GameObject.Find("еDид").transform);
    }
}
